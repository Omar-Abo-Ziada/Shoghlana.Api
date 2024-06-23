using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

            List<AddJobDTO> jobDTOs = mapper.Map<List<Job>, List<AddJobDTO>>(jobs);

            for (int i = 0; i < jobs.Count; i++)
            {
                //jobDTOs[i].clientName = jobs[i].Client.Name;
                //jobDTOs[i].CategoryTitle = jobs[i].Category.Title;

                //var client = _unitOfWork.clientRepository.GetById(jobDTOs[i].ClientId);
                //jobDTOs[i].clientName = client?.Name ?? "NA";

                //var category = _unitOfWork.categoryRepository.GetById(jobDTOs[i].CategoryId);
                //jobDTOs[i].CategoryTitle = category?.Title ?? "NA";

                //var freelancer = _unitOfWork.freelancerRepository.GetById((int)jobDTOs[i].AcceptedFreelancerId);
                //jobDTOs[i].AcceptedFreelancerName = freelancer?.Title ?? "NA";

                // it is calculated automatically in the prop from the count of proposal List 
           //     jobDTOs[i].ProposalsCount = _unitOfWork.proposalRepository.GetCount();

                foreach (JobSkills jobSkill in jobs[i].skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                    jobDTOs[i].Skills.Add(new SkillDTO
                    {
                        Title = skill.Title,
                        //Id = skill.Id,
                    });
                }
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

            PaginatedListDTO<Job> jobs = _unitOfWork.jobRepository
                  .GetPaginatedJobs(status , MinBudget, MaxBudget,ClientId, FreelancerId, HasManyProposals, IsNew, page, pageSize, requestBody);

            paginatedJobs.Items = mapper.Map<IEnumerable<Job>, IEnumerable<GetJobDTO>>(jobs.Items);
            paginatedJobs.TotalItems = jobs.TotalItems;
            paginatedJobs.CurrentPage = jobs.CurrentPage;
            paginatedJobs.TotalPages = jobs.TotalPages;

            if(paginatedJobs.Items is null) 
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
                    Status = 400 , 
                    Message = "No Jobs Found with this filteration"
                };
            }

            List<GetJobDTO> jobsDTOs = (List<GetJobDTO>) paginatedJobs.Items;

            //foreach (GetJobDTO job in paginatedJobs.Items)
            //{
            //  //  GetJobDTO jobDTO = mapper.Map<Job , GetJobDTO>(job);

            //  //  var client = _unitOfWork.clientRepository.GetById(jobDTO.ClientId);
            //    //jobDTO.clientName = client?.Name ?? "NA";

            //    //var category = _unitOfWork.categoryRepository.GetById(jobDTO.CategoryId);
            //    //jobDTO.CategoryTitle = category?.Title ?? "NA";

            //    //if(jobDTO.AcceptedFreelancerId is not null)
            //    //{
            //    //    var freelancer = _unitOfWork.freelancerRepository.GetById((int)jobDTO.AcceptedFreelancerId);
            //    //    jobDTO.AcceptedFreelancerName = freelancer?.Title ?? "NA";

            //    //}
            //    // it is calculated automatically in the prop from the count of proposal List 
            //    // jobDTO.ProposalsCount = _unitOfWork.proposalRepository.GetCount();

            //    jobsDTOs.Add(jobDTO);
            //}

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = new PaginatedListDTO<GetJobDTO>
                {
                    CurrentPage = paginatedJobs.CurrentPage,
                    TotalPages = paginatedJobs.TotalPages,
                    TotalItems = paginatedJobs.TotalItems,
                    Items = jobsDTOs
                },
                Status = 200 , 
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

            //PaginatedListDTO<GetJobDTO> paginatedJobs = await _unitOfWork.jobRepository
            //      .GetPaginatedJobsAsync(status, MinBudget, MaxBudget, ClientId, FreelancerId, page, pageSize, requestBody);

            if (paginatedJobs.Items is null)
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


            //foreach (Job job in paginatedJobs.Items)
            //{
            //    AddJobDTO jobDTO = mapper.Map<Job, AddJobDTO>(job);

            //    //var client = _unitOfWork.clientRepository.GetById(jobDTO.ClientId);
            //    //jobDTO.clientName = client?.Name ?? "NA";

            //    //var category = _unitOfWork.categoryRepository.GetById(jobDTO.CategoryId);
            //    //jobDTO.CategoryTitle = category?.Title ?? "NA";

            //    //if (jobDTO.AcceptedFreelancerId is not null)
            //    //{
            //    //    var freelancer = _unitOfWork.freelancerRepository.GetById((int)jobDTO.AcceptedFreelancerId);
            //    //    jobDTO.AcceptedFreelancerName = freelancer?.Title ?? "NA";

            //    //}
            //    // it is calculated automatically in the prop from the count of proposal List 
            //    // jobDTO.ProposalsCount = _unitOfWork.proposalRepository.GetCount();

            //    jobsDTOs.Add(jobDTO);
            //}

            List<GetJobDTO> jobsDTOs = (List<GetJobDTO>)paginatedJobs.Items;

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = new PaginatedListDTO<GetJobDTO>
                {
                    CurrentPage = paginatedJobs.CurrentPage,
                    TotalPages = paginatedJobs.TotalPages,
                    TotalItems = paginatedJobs.TotalItems,
                    Items = jobsDTOs
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

            AddJobDTO jobDTO = new AddJobDTO();

            List<SkillDTO> skillDTOs = new List<SkillDTO>();

            foreach (var skill in job.skills)
            {
                SkillDTO skillDTO = mapper.Map<SkillDTO>(skill);

                skillDTOs.Add(skillDTO);
            }

            jobDTO.Skills = skillDTOs;

            if (job.Proposals is not null)
            {
                List<GetProposalDTO> proposalDTOs = new List<GetProposalDTO>();

                foreach (var proposal in job.Proposals)
                {
                    GetProposalDTO proposalDTO = mapper.Map<GetProposalDTO>(proposal);

                    proposalDTOs.Add(proposalDTO);
                }

                //jobDTO.Proposals = proposalDTOs;
            }

            //jobDTO.clientName = job.Client?.Name ?? "NA";

            //jobDTO.CategoryTitle = job.Category?.Title ?? "NA";

            Freelancer? acceptedFreelancer = _unitOfWork.freelancerRepository.GetById(job.AcceptedFreelancerId ?? 0);

            //if (acceptedFreelancer is not null)
            //{
            //    jobDTO.AcceptedFreelancerId = acceptedFreelancer.Id;
            //    jobDTO.AcceptedFreelancerName = acceptedFreelancer.Name;
            //}

            jobDTO = mapper.Map<Job, AddJobDTO>(job);

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
                jobs = _unitOfWork.jobRepository.FindAll(["Client", "Category", "skills"], j => j.AcceptedFreelancerId == id)
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

            List<AddJobDTO> jobDTOs = mapper.Map<List<Job>, List<AddJobDTO>>(jobs);

            for (int i = 0; i < jobs.Count; i++)
            {
                //jobDTOs[i].clientName = jobs[i].Client.Name;
                //jobDTOs[i].CategoryTitle = jobs[i].Category.Title;

                foreach (JobSkills jobSkill in jobs[i].skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                    jobDTOs[i].Skills.Add(new SkillDTO
                    {
                        Title = skill.Title,
                        //Id = skill.Id,
                    });
                }
            }
            return new GeneralResponse
            {
                IsSuccess = true,
                Data = jobDTOs,
                Message = "All jobs for this freelancer retrieved successfully"
            };
            // rate?????
        }

        public ActionResult<GeneralResponse> GetJobsByCategoryId(int id)
        {
            Category? category = _unitOfWork.categoryRepository.GetCategorytWithJobs(id);

            if (category != null)
            {
                CategoryDTO categoryDTO = mapper.Map<CategoryDTO>(category);

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 200,
                    Data = categoryDTO
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 400,
                Message = "Category Not Found !"
            };
        }

        public ActionResult<GeneralResponse> GetJobsByCategoryIds([FromQuery] List<int> ids)
        {
            List<Job> jobs = new List<Job>();

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
                if (tempJobs != null)
                {
                    jobs.AddRange(tempJobs);
                }
            }

            if (jobs.Count > 0)
            {
                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = jobs,
                    Message = "All messages for this categories retrieved successfully"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = false,
                Data = null,
                Message = "No jobs found for these Ids"
            };
        }

        public ActionResult<GeneralResponse> GetByClientId(int id)
        {
            List<Job> jobs;
            try
            {
                jobs = _unitOfWork.jobRepository.FindAll(new string[] { "Freelancer", "Category", "skills" }, j => j.ClientId == id)
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

            List<AddJobDTO> jobDTOs = mapper.Map<List<Job>, List<AddJobDTO>>(jobs);

            for (int i = 0; i < jobs.Count; i++)
            {
                //jobDTOs[i].AcceptedFreelancerName = jobs[i]?.AcceptedFreelancer?.Name;
                //jobDTOs[i].AcceptedFreelancerId = jobs[i]?.AcceptedFreelancer?.Id;

                //jobDTOs[i].CategoryTitle = jobs[i]?.Category?.Title;

                foreach (JobSkills jobSkill in jobs[i].skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                    jobDTOs[i].Skills.Add(new SkillDTO
                    {
                        Title = skill.Title,
                        //Id = skill.Id,
                    });
                }
            }

            return new GeneralResponse
            {
                IsSuccess = true,
                Data = jobDTOs,
                Message = "All jobs for this client retrieved successfully"
            };

            // rate?????
        }

        public ActionResult<GeneralResponse> Add(AddJobDTO jobDto)
        {
            Job job = mapper.Map<AddJobDTO, Job>(jobDto);

            //foreach(SkillDTO skillDTO in jobDto.skillsDTO) 
            //{
            //    JobSkills skill = jobServiceSkills.Find(js => {js.SkillId == skillDTO.Id && js.JobId ==  });

            //    job.skills.Add(skill);
            //}

            try
            {
                job.skills = null;

                _unitOfWork.jobRepository.Add(job);

                _unitOfWork.Save();

                List<JobSkills> JobSkills = new List<JobSkills>();

                foreach (SkillDTO skillDTO in jobDto.Skills)
                {
                    Skill skill = new Skill()
                    {
                        Title = skillDTO.Title,
                        Description = skillDTO.Description,
                    };

                    _unitOfWork.skillRepository.Add(skill);

                    _unitOfWork.Save();

                    var jobSkill = new JobSkills
                    {
                        SkillId = skill.Id,
                        JobId = job.Id
                    };

                    JobSkills.Add(jobSkill);
                }

                //foreach (GetProposalDTO getProposalDTO in jobDto.Proposals)
                //{
                //    Proposal proposal = mapper.Map<GetProposalDTO, Proposal>(getProposalDTO);

                //    job?.Proposals?.Add(proposal);

                //    //job.Proposals.Add(new JobSkills
                //    //{
                //    //    SkillId = skillDTO.Id,
                //    //    JobId = job.Id
                //    //});
                //}

                //Rate rate = mapper.Map<RateDTO , Rate>(jobDto.Rate);

                //job.Rate = rate;

                _unitOfWork.jobRepository.Update(job);

                _unitOfWork.Save();

                job.skills = JobSkills;

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
                Data = jobDto,
                Message = "Job is added successfully",
                Status = 200 ,
            };
        }

        public ActionResult<GeneralResponse> update(AddJobDTO jobDto)
        {
            Job? job = _unitOfWork.jobRepository.GetById(jobDto.Id);

            //  job = mapper.Map<JobDTO, Job>(jobDto);
            job.Description = jobDto.Description;
            job.Title = jobDto.Title;
            job.MaxBudget = jobDto.MaxBudget;
            job.MinBudget = jobDto.MinBudget;
            job.ExperienceLevel = jobDto.ExperienceLevel;
            job.CategoryId = jobDto.CategoryId;

            List<JobSkills> jobSkills = _unitOfWork.jobSkillsRepository
                                   .FindAll(criteria: js => js.JobId == jobDto.Id)
                                   .ToList();

            _unitOfWork.jobSkillsRepository.DeleteRange(jobSkills);

            List<JobSkills> skills = new List<JobSkills>();
            foreach (SkillDTO skillDto in jobDto.Skills)
            {
                skills.Add(new JobSkills
                {
                    //SkillId = skillDto.Id,
                    JobId = jobDto.Id
                });
            }

            job.skills = skills;

            try
            {
                _unitOfWork.jobRepository.Update(job);

                _unitOfWork.Save();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Data = jobDto,
                    Message = "Job updated successfully"
                };
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

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Data = null,
                    Message = "Job was deleted successfully"
                };
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
    }
}