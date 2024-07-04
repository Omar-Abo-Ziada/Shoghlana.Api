using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Enums;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Implementaions
{
    public class JobService : GenericService<Job>, IJobService
    {
        private readonly IMapper mapper;

        public JobService(IUnitOfWork unitOfWork, IGenericRepository<Job> repository, IMapper mapper) : base(unitOfWork, repository)
        {
            this.mapper = mapper;
        }

        public ActionResult<GeneralResponse> GetAll()
        {
            List<Job> jobs = _unitOfWork.jobRepository.FindAll(["Client", "Category", "skills"]).ToList();

            List<GetJobDTO> jobDTOs = mapper.Map<List<Job>, List<GetJobDTO>>(jobs);

            for (int i = 0; i < jobs.Count; i++)
            {
                List<SkillDTO> SkillDTOs = new List<SkillDTO>();
                foreach (JobSkills jobSkill in jobs[i].skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                    SkillDTOs.Add(new SkillDTO
                    {
                        Title = skill.Title,
                        Id = skill.Id,
                        Description = skill.Description
                    });
                }

                jobDTOs[i].Skills = SkillDTOs;
            }

            return new GeneralResponse
            {
                IsSuccess = true,
                Data = jobDTOs,
                Message = "All jobs retrieved successfully"
            };
        }


        public ActionResult<GeneralResponse> GetPaginatedJobs
         (JobStatus? status , int? MinBudget , int? MaxBudget , int? ClientId , int? FreelancerId , bool? HasManyProposals,
          bool? IsNew , int page , int pageSize , PaginatedJobsRequestBody requestBody )
        {
            PaginatedListDTO<GetJobDTO> paginatedJobs = new PaginatedListDTO<GetJobDTO>();

            requestBody.Includes = ["Proposals"];

            PaginatedListDTO<Job> jobs = _unitOfWork.jobRepository
                  .GetPaginatedJobs(status , MinBudget, MaxBudget,ClientId, FreelancerId, HasManyProposals, IsNew, page, pageSize, requestBody);

            paginatedJobs.Items = mapper.Map<IEnumerable<Job>, IEnumerable<GetJobDTO>>(jobs.Items); // if jobs.items = null >> paginatedjobs.items = empty array not null

            // Iterate through the paginated jobs to manually set the additional property
            foreach (var jobDTO in paginatedJobs.Items)
            {
                //Job correspondingJob = jobs.Items.FirstOrDefault(job => job.Id == jobDTO.Id); // Or any unique identifier

                if(jobDTO.ClientId > 0)
                {
                    jobDTO.clientName = _unitOfWork.clientRepository.Find(criteria: c => c.Id == jobDTO.ClientId)?.Name ?? "NA";
                }

                if (jobDTO.AcceptedFreelancerId > 0)
                {
                    jobDTO.AcceptedFreelancerName = _unitOfWork.freelancerRepository.Find(criteria: f => f.Id == jobDTO.AcceptedFreelancerId)?.Name??"NA";
                }

                jobDTO.ProposalsCount = jobDTO?.Proposals?.Count??0;

                // then I don't need the proposal list any more to make the payload lighter
                jobDTO.Proposals = null;

            }

            paginatedJobs.TotalItems = jobs.TotalItems;
            paginatedJobs.CurrentPage = jobs.CurrentPage;
            paginatedJobs.TotalPages = jobs.TotalPages;
                
            if(jobs.Items is null) 
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = new PaginatedListDTO<GetJobDTO>
                    {
                        CurrentPage = paginatedJobs.CurrentPage,
                        TotalPages = paginatedJobs.TotalPages,
                        TotalItems = paginatedJobs.TotalItems,
                        Items = null
                    },
                    Status = 400 , 
                    Message = "No Jobs Found with this filteration"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = new PaginatedListDTO<GetJobDTO>
                {
                    CurrentPage = paginatedJobs.CurrentPage,
                    TotalPages = paginatedJobs.TotalPages,
                    TotalItems = paginatedJobs.TotalItems,
                    Items = paginatedJobs.Items
                },
                Status = 200 
            };
        }

        public async Task<ActionResult<GeneralResponse>> GetPaginatedJobsAsync
         (JobStatus? status, int? MinBudget, int? MaxBudget, int? ClientId, int? FreelancerId, bool? HasManyProposals, bool? IsNew,
            int page, int pageSize, PaginatedJobsRequestBody requestBody)
        {

            PaginatedListDTO<GetJobDTO> paginatedJobs = new PaginatedListDTO<GetJobDTO>();


            PaginatedListDTO<Job> jobs = await _unitOfWork.jobRepository
                  .GetPaginatedJobsAsync(status, MinBudget, MaxBudget, ClientId, FreelancerId, HasManyProposals, IsNew, page, pageSize, requestBody);

            paginatedJobs.Items = mapper.Map<IEnumerable<Job>, IEnumerable<GetJobDTO>>(jobs.Items);
          
            paginatedJobs.TotalItems = jobs.TotalItems;
            paginatedJobs.CurrentPage = jobs.CurrentPage;
            paginatedJobs.TotalPages = jobs.TotalPages;

            if (jobs.Items is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = new PaginatedListDTO<AddJobDTO>
                    {
                        CurrentPage = paginatedJobs.CurrentPage,
                        TotalPages = paginatedJobs.TotalPages,
                        TotalItems = paginatedJobs.TotalItems,
                        Items = null
                    },
                    Status = 400,
                    Message = "No Jobs Found with this filteration"
                };
            }


            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = new PaginatedListDTO<GetJobDTO>
                {
                    CurrentPage = paginatedJobs.CurrentPage,
                    TotalPages = paginatedJobs.TotalPages,
                    TotalItems = paginatedJobs.TotalItems,
                    Items = paginatedJobs.Items
                },
                Status = 200,
            }; 
        }

        public ActionResult<GeneralResponse> Get(int id) 
        {
            Job? job = _unitOfWork.jobRepository.Find(criteria: j => j.Id == id, includes: ["Proposals", "skills", "Category", "Client"]);

            if (job is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "No Job found with this ID"
                };
            }

            GetJobDTO jobDTO = new GetJobDTO();
            jobDTO = mapper.Map<GetJobDTO>(job);


            if(job.skills != null && job.skills.Any())
            {
                List<SkillDTO> skillDTOs = new List<SkillDTO>();
                foreach (JobSkills JobSkill in job.skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(JobSkill.SkillId);
                 
                    if (skill is not null)
                    {
                        SkillDTO skillDTO = mapper.Map<Skill, SkillDTO>(skill);
                        skillDTOs.Add(skillDTO);
                    }
                }
                jobDTO.Skills = skillDTOs;
            }



            if (job.Proposals is not null)
            {
                List<GetProposalDTO> proposalDTOs = new List<GetProposalDTO>();

                foreach (Proposal proposal in job.Proposals)
                {
                    GetProposalDTO proposalDTO = mapper.Map<GetProposalDTO>(proposal);

                    proposalDTOs.Add(proposalDTO);
                }

                jobDTO.Proposals = proposalDTOs;
            }

            jobDTO.clientName = job.Client?.Name ?? "Anonymous user";


            Freelancer? acceptedFreelancer = _unitOfWork.freelancerRepository.GetById(job.AcceptedFreelancerId ?? 0);

            if (acceptedFreelancer is not null)
            {
                jobDTO.AcceptedFreelancerId = acceptedFreelancer.Id;
                jobDTO.AcceptedFreelancerName = acceptedFreelancer.Name;
            }


            return new GeneralResponse
            {
                IsSuccess = true,
                Data = jobDTO,
                Message = "Job is retrieved successfully"
            };
        }

        public ActionResult<GeneralResponse> GetByFreelancerId(int id)
        {
            List<Job> jobs;

            try
            {
                jobs = _unitOfWork.jobRepository.FindAll(["Client", "Category", "skills", "Rate"], j => j.AcceptedFreelancerId == id)
                                                        .ToList();
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Message = ex.Message
                };
            }

            if(jobs != null && jobs.Any())
            {
                List<GetJobDTO> jobDTOs = mapper.Map<List<Job>, List<GetJobDTO>>(jobs);

                for (int i = 0; i < jobs.Count; i++)
                {
                    if (jobs[i].Rate is not null)
                    {
                        RateDTO RateDto = mapper.Map<Rate, RateDTO>(jobs[i].Rate);
                        jobDTOs[i].Rate = RateDto;
                    }

                    if (jobs[i].skills is not null && jobs[i].skills.Any())
                    {
                        List<SkillDTO> SkillDTOs = new List<SkillDTO>();

                        foreach (JobSkills jobSkill in jobs[i].skills)
                        {
                            Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                            SkillDTOs.Add(new SkillDTO
                            {
                                Title = skill.Title,
                                Id = skill.Id
                            });
                        }
                        jobDTOs[i].Skills = SkillDTOs;
                    }
                }

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Data = jobDTOs,
                    Message = "All jobs for this freelancer retrieved successfully"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = false,
                Data = null,
                Message = "No jobs found for this freelancer"
            };
          
            
        }

        public ActionResult<GeneralResponse> GetJobsByCategoryId(int id)
        {
           List<Job> Jobs = _unitOfWork.jobRepository.GetByCategoryId(id);

            if (Jobs != null && Jobs.Any())
            {
                List<GetJobDTO> JobDTOs = mapper.Map<List<GetJobDTO>>(Jobs);

                foreach(GetJobDTO job in JobDTOs)
                {
                  Client? client = _unitOfWork.clientRepository.GetById(job.ClientId);

                    if(client != null)
                    {
                        job.clientName = client.Name;
                    }

                    if (job.AcceptedFreelancerId != null)
                    {
                        Freelancer? freelancer = _unitOfWork.freelancerRepository
                                                 .GetById((int)job.AcceptedFreelancerId);

                        job.AcceptedFreelancerName = freelancer?.Name;
                    }

                    Category? category = _unitOfWork.categoryRepository.GetById(job.CategoryId);
                    job.CategoryTitle = category?.Title;
                }

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 200,
                    Data = JobDTOs
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 400,
                Message = "No jobs Found for this category !"
            };
        }

        public ActionResult<GeneralResponse> GetJobsByCategoryIds(List<int> ids)
        {
            List<GetJobDTO> jobs = new List<GetJobDTO>();

            foreach (int id in ids)
            {
                List<Job> tempJobs = new List<Job>();
                try
                {
                    tempJobs = _unitOfWork.jobRepository.FindAll(criteria: j => j.CategoryId == id)
                                                    .ToList();
                }
                catch (Exception ex)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = ex.Message
                    };
                }
                if (tempJobs != null && tempJobs.Any())
                {
                    var TempGetJobDtos = mapper.Map<List<Job> , List<GetJobDTO>>(tempJobs);
                    jobs.AddRange(TempGetJobDtos); 
                }
            }

            if (jobs.Count > 0)
            {
                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = jobs,
                    Message = "All jobs for this categories retrieved successfully"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = false,
                Data = null,
                Message = "No jobs found for these categories"
            };
        }

        public ActionResult<GeneralResponse> GetByClientId(int id)
        {
            List<Job> jobs;
            try
            {
                jobs = _unitOfWork.jobRepository.FindAll(new string[] { "AcceptedFreelancer", "Category", "skills" }, j => j.ClientId == id)
                                        .ToList();
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Message = ex.Message
                };
            }

            if (jobs.Any())
            {
                List<GetJobDTO> jobDTOs = mapper.Map<List<Job>, List<GetJobDTO>>(jobs);

                for (int i = 0; i < jobs.Count; i++)
                {
                    jobDTOs[i].AcceptedFreelancerName = jobs[i]?.AcceptedFreelancer?.Name;
                    jobDTOs[i].AcceptedFreelancerId = jobs[i]?.AcceptedFreelancer?.Id;

                    jobDTOs[i].CategoryTitle = jobs[i]?.Category?.Title;

                    List<SkillDTO> SkillDTOs = new List<SkillDTO>();
                    foreach (JobSkills jobSkill in jobs[i].skills)
                    {
                        Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                        SkillDTOs.Add(new SkillDTO
                        {
                            Title = skill.Title,
                            Id = skill.Id,
                        });
                    }
                    jobDTOs[i].Skills = SkillDTOs;
                }

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Data = jobDTOs,
                    Message = "All jobs for this client retrieved successfully"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = false,
                Data = null,
                Message = "No jobs found for this client"
            };
        }

        public ActionResult<GeneralResponse> Add(AddJobDTO jobDto)
        {
            Job job = mapper.Map<AddJobDTO, Job>(jobDto);

            try
            {

                _unitOfWork.jobRepository.Add(job);

                _unitOfWork.Save();

                List<JobSkills> JobSkills = new List<JobSkills>();

                foreach (int skillID in jobDto.SkillsIds)
                {

                   Skill? skill = _unitOfWork.skillRepository.GetById(skillID);


                    if(skill is not null)
                    {
                        var jobSkill = new JobSkills
                        {
                            SkillId = skill.Id,
                            JobId = job.Id
                        };

                        JobSkills.Add(jobSkill);
                    }
                }

                if(JobSkills.Any())
                {
                    _unitOfWork.jobSkillsRepository.AddRange(JobSkills);
                    _unitOfWork.jobSkillsRepository.save();
                }
                
            }

            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Message = ex.Message
                };
            }
            return new GeneralResponse
            {
                IsSuccess = true,
                Data = jobDto,
                Message = "Job is added successfully",
                Status = 200 ,
            };
        }

        public ActionResult<GeneralResponse> update(AddJobDTO jobDto)
        {
            Job? job = _unitOfWork.jobRepository.GetById((int)jobDto.Id);

            job.Id = (int) jobDto.Id;
            job.Description = jobDto.Description;
            job.Title = jobDto.Title;
            job.MaxBudget = jobDto.MaxBudget;
            job.MinBudget = jobDto.MinBudget;
            job.ExperienceLevel = jobDto.ExperienceLevel;
            job.CategoryId = jobDto.CategoryId;
            job.PostTime = (DateTime) jobDto.PostTime;
            job.Status = (JobStatus) jobDto.Status;
            job.DurationInDays = jobDto.DurationInDays;
            job.ExperienceLevel = jobDto.ExperienceLevel;
        //    job.ClientId = jobDto.ClientId;

            List<JobSkills> jobSkills = _unitOfWork.jobSkillsRepository
                                   .FindAll(criteria: js => js.JobId == jobDto.Id)
                                   .ToList();

            _unitOfWork.jobSkillsRepository.DeleteRange(jobSkills);

            List<JobSkills> skills = new List<JobSkills>();
            foreach (int skillId in jobDto.SkillsIds)
            {
                Skill? skill = _unitOfWork.skillRepository.GetById(skillId);
                if(skill is not null)
                {
                    skills.Add(new JobSkills
                    {
                        SkillId = skill.Id,
                        JobId = (int)jobDto.Id
                    });
                }
               
            }

            if(skills is not null)
            {
                try
                {
                    _unitOfWork.jobSkillsRepository.AddRange(skills);
                }
                catch (Exception ex)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = ex.Message
                    };
                }
            }

            _unitOfWork.Save();
            return new GeneralResponse
            {
                IsSuccess = true,
                Data = jobDto,
                Message = "Job updated successfully"
            };
        }

        public ActionResult<GeneralResponse> delete(int id)
        {
            Job? job = _unitOfWork.jobRepository.GetById(id);

            if (job is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = id,
                    Message = $"No Job found with this ID : {id}",
                    Status = 404,
                };
            }

            List<JobSkills> jobSkills = _unitOfWork.jobSkillsRepository
                                       .FindAll(criteria: js => js.JobId == id)
                                       .ToList();

            if (jobSkills.Count > 0)
            {
                _unitOfWork.jobSkillsRepository.DeleteRange(jobSkills);
            }


            List<Proposal> proposals = _unitOfWork.proposalRepository
                                      .FindAll(criteria: p => p.JobId == id)
                                      .ToList();

            if (proposals.Count > 0)
            {
                foreach (Proposal proposal in proposals)
                {
                    List<ProposalImages> images = _unitOfWork.proposalImageRepository
                                              .FindAll(criteria: pi => pi.ProposalId == proposal.Id)
                                              .ToList();

                    _unitOfWork.proposalImageRepository.DeleteRange(images);
                }

                _unitOfWork.proposalRepository.DeleteRange(proposals);
            }


            Rate? rate = _unitOfWork.rateRepository.Find(criteria: r => r.JobId == id);

            if (rate != null)
            {
                _unitOfWork.rateRepository.Delete(rate);
            }

            try
            {
                _unitOfWork.jobRepository.Delete(job);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Message = ex.Message
                };
            }

            return new GeneralResponse
            {
                IsSuccess = true,
                Data = null,
                Message = "Job was deleted successfully"
            };
        }

        public async Task <ActionResult<GeneralResponse>> SearchByJobTitleAsync(string KeyWord) 
        {

            IList<Job> Jobs = (IList<Job>) await _unitOfWork.jobRepository
           .FindAllAsync(criteria: j => j.Title.Contains(KeyWord), includes: new string[] { "Rate", "skills" }); 
           
            
            if(Jobs.Count() == 0)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "No jobs match this search key word"
                };
            }
           

           List<GetJobDTO> GetJobDtos = mapper.Map<IEnumerable<Job>, IEnumerable<GetJobDTO>>(Jobs)
                                             .ToList();

            for(int i = 0; i < Jobs.Count(); i++)
            {
                int? RateId = Jobs[i].Rate?.Id;

                if(RateId is not null)
                {
                    Rate? rate = await _unitOfWork.rateRepository.GetByIdAsync((int)RateId);
                    if (rate is not null)
                    {
                        RateDTO RateDto = mapper.Map<Rate, RateDTO>(rate);
                        GetJobDtos[i].Rate = RateDto;
                    }
                }


                List<SkillDTO> SkillDTOs = new List<SkillDTO>();

                foreach(JobSkills JobSkill in Jobs[i].skills)
                {
                  Skill? skill = await _unitOfWork.skillRepository.GetByIdAsync(JobSkill.SkillId);

                    if(skill is not null)
                    {
                        SkillDTO SkillDto = mapper.Map<Skill, SkillDTO>(skill);
                        SkillDTOs.Add(SkillDto);
                    }
                }

                GetJobDtos[i].Skills = SkillDTOs;
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = GetJobDtos,
                Message = "All jobs match this key word retrieved successfully"
            };
        }
    }
}