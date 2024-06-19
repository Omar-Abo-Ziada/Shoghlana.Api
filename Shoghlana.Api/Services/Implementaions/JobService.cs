using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Migrations;
using Shoghlana.EF.Repositories;
using System.Linq.Expressions;

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

            List<JobDTO> jobDTOs = mapper.Map<List<Job>, List<JobDTO>>(jobs);

            for (int i = 0; i < jobs.Count; i++)
            {
                jobDTOs[i].clientName = jobs[i].Client.Name;
                jobDTOs[i].CategoryTitle = jobs[i].Category.Title;

                var client = _unitOfWork.clientRepository.GetById(jobDTOs[i].ClientId);
                jobDTOs[i].clientName = client?.Name ?? "NA";

                var category = _unitOfWork.categoryRepository.GetById(jobDTOs[i].CategoryId);
                jobDTOs[i].CategoryTitle = category?.Title ?? "NA";

                var freelancer = _unitOfWork.freelancerRepository.GetById(jobDTOs[i].AcceptedFreelancerId);
                jobDTOs[i].AcceptedFreelancerName = freelancer?.Title ?? "NA";

                jobDTOs[i].ProposalsCount = _unitOfWork.proposalRepository.GetCount();

                foreach (JobSkills jobSkill in jobs[i].skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                    jobDTOs[i].Skills.Add(new SkillDTO
                    {
                        Title = skill.Title,
                        Id = skill.Id,
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
         (int MinBudget, int MaxBudget, int CategoryId, int ClientId, int FreelancerId, int page, int pageSize, string[] includes = null)
        {
            PaginatedListDTO<Job> paginatedJobs = _unitOfWork.jobRepository
                  .GetPaginatedJobs(MinBudget, MaxBudget, CategoryId, ClientId, FreelancerId, page, pageSize, includes);

            if(paginatedJobs.Items is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = new PaginatedListDTO<JobDTO>
                    {
                        CurrentPage = paginatedJobs.CurrentPage,
                        TotalPages = paginatedJobs.TotalPages,
                        TotalItems = paginatedJobs.TotalItems,
                        Items = null
                    },
                    Status = 200 , 
                    Message = "No Jobs Found with this filteration"
                };
            }

            List<JobDTO> jobsDTOs = new List<JobDTO> ();

            foreach (Job job in paginatedJobs.Items)
            {
                JobDTO jobDTO = mapper.Map<Job , JobDTO>(job);

                var client = _unitOfWork.clientRepository.GetById(jobDTO.ClientId);
                jobDTO.clientName = client?.Name ?? "NA";

                var category = _unitOfWork.categoryRepository.GetById(jobDTO.CategoryId);
                jobDTO.CategoryTitle = category?.Title ?? "NA";

                var freelancer = _unitOfWork.freelancerRepository.GetById(jobDTO.AcceptedFreelancerId);
                jobDTO.AcceptedFreelancerName = freelancer?.Title ?? "NA";

                jobDTO.ProposalsCount = _unitOfWork.proposalRepository.GetCount();

                jobsDTOs.Add(jobDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = new PaginatedListDTO<JobDTO>
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
        (int MinBudget, int MaxBudget, int CategoryId, int ClientId, int FreelancerId, int page, int pageSize, string[] includes = null)
        {
            PaginatedListDTO<Job> paginatedJobs = await _unitOfWork.jobRepository
                .GetPaginatedJobsAsync(MinBudget, MaxBudget, CategoryId, ClientId, FreelancerId, page, pageSize, includes);

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = paginatedJobs,
                Status = 200
            };
        }

        public ActionResult<GeneralResponse> Get(int id)
        {
            Job? job = new Job();

            JobDTO jobDTO = new JobDTO();
            try
            {
                job = _unitOfWork.jobRepository.Find(criteria: j => j.Id == id, includes: new string[] { "Proposals", "skills", "Category", "Client" });

                jobDTO = mapper.Map<Job, JobDTO>(job);
                jobDTO.clientName = job.Client.Name;
                jobDTO.CategoryTitle = job.Category.Title;

                foreach (Proposal proposal in job.Proposals)
                {
                    Freelancer? freelancer = _unitOfWork.freelancerRepository.GetById(proposal.FreelancerId);

                    jobDTO.Freelancers.Add(new FreelancerDTO
                    {
                        Name = freelancer.Name,
                        Id = freelancer.Id
                    });

                    jobDTO.Proposals.Add(new ProposalDTO
                    {
                        Description = proposal.Description,
                        Id = proposal.Id
                    });
                }

                foreach (JobSkills jobSkill in job.skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                    jobDTO.Skills.Add(new SkillDTO
                    {
                        Title = skill.Title,
                        Id = skill.Id
                    });
                }
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

            return new GeneralResponse
            {
                IsSuccess = true,
                Data = jobDTO,
                Message = "Job is retrieved successfully"
            };
            // rate?????
        }

        public ActionResult<GeneralResponse> GetByFreelancerId(int id)
        {
            List<Job> jobs;

            try
            {
                jobs = _unitOfWork.jobRepository.FindAll(["Client", "Category", "skills"], j => j.FreelancerId == id)
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

            List<JobDTO> jobDTOs = mapper.Map<List<Job>, List<JobDTO>>(jobs);

            for (int i = 0; i < jobs.Count; i++)
            {
                jobDTOs[i].clientName = jobs[i].Client.Name;
                jobDTOs[i].CategoryTitle = jobs[i].Category.Title;

                foreach (JobSkills jobSkill in jobs[i].skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                    jobDTOs[i].Skills.Add(new SkillDTO
                    {
                        Title = skill.Title,
                        Id = skill.Id,
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

            List<JobDTO> jobDTOs = mapper.Map<List<Job>, List<JobDTO>>(jobs);

            for (int i = 0; i < jobs.Count; i++)
            {
                jobDTOs[i].AcceptedFreelancerName = jobs[i].Freelancer.Name;
                jobDTOs[i].AcceptedFreelancerId = jobs[i].Freelancer.Id;
                jobDTOs[i].CategoryTitle = jobs[i].Category.Title;

                foreach (JobSkills jobSkill in jobs[i].skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                    jobDTOs[i].Skills.Add(new SkillDTO
                    {
                        Title = skill.Title,
                        Id = skill.Id,
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

        public ActionResult<GeneralResponse> Add(JobDTO jobDto)
        {
            Job job = mapper.Map<JobDTO, Job>(jobDto);

            //foreach(SkillDTO skillDTO in jobDto.skillsDTO) 
            //{
            //    JobSkills skill = jobServiceSkills.Find(js => {js.SkillId == skillDTO.Id && js.JobId ==  });

            //    job.skills.Add(skill);
            //}

            try
            {
                _unitOfWork.jobRepository.Add(job);

                _unitOfWork.Save();

                foreach (SkillDTO skillDTO in jobDto.Skills)
                {
                    job.skills.Add(new JobSkills
                    {
                        SkillId = skillDTO.Id,
                        JobId = job.Id
                    });
                }
                _unitOfWork.jobRepository.Update(job);

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
                Message = "Job is added successfully"
            };
        }

        public ActionResult<GeneralResponse> update(JobDTO jobDto)
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
                    SkillId = skillDto.Id,
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