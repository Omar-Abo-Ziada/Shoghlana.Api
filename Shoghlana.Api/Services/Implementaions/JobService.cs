using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repositories;

namespace Shoghlana.Api.Services.Implementaions
{
    public class JobService : GenericService<Job> , IJobService
    {
        private readonly IMapper mapper;

        public JobService(IUnitOfWork unitOfWork, IGenericRepository<Job> repository , IMapper mapper) : base(unitOfWork, repository)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Job> jobs = _unitOfWork.jobRepository.FindAll(["Client", "Category", "skills"]).ToList();

            List<JobDTO> jobDTOs = mapper.Map<List<Job>, List<JobDTO>>(jobs);

            for (int i = 0; i < jobs.Count; i++)
            {
                jobDTOs[i].clientName = jobs[i].Client.Name;
                jobDTOs[i].categoryTitle = jobs[i].Category.Title;

                foreach (JobSkills jobSkill in jobs[i].skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                    jobDTOs[i].skillsDTO.Add(new SkillDTO
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

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> Get(int id)
        {
            Job? job = new Job();

            JobDTO jobDTO = new JobDTO();
            try
            {
                job = _unitOfWork.jobRepository.Find(criteria: j => j.Id == id, includes: new string[] { "Proposals", "skills", "Category", "Client" });

                jobDTO = mapper.Map<Job, JobDTO>(job);
                jobDTO.clientName = job.Client.Name;
                jobDTO.categoryTitle = job.Category.Title;

                foreach (Proposal proposal in job.Proposals)
                {
                    Freelancer? freelancer = _unitOfWork.freelancerRepository.GetById(proposal.FreelancerId);

                    jobDTO.freelancersDTO.Add(new FreelancerDTO
                    {
                        Name = freelancer.Name,
                        Id = freelancer.Id
                    });

                    jobDTO.proposalsDTO.Add(new ProposalDTO
                    {
                        Description = proposal.Description,
                        Id = proposal.Id
                    });
                }

                foreach (JobSkills jobSkill in job.skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                    jobDTO.skillsDTO.Add(new SkillDTO
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

        [HttpGet("freelancer")]
        public ActionResult<GeneralResponse> GetByFreelancerId([FromQuery] int id)
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
                jobDTOs[i].categoryTitle = jobs[i].Category.Title;

                foreach (JobSkills jobSkill in jobs[i].skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                    jobDTOs[i].skillsDTO.Add(new SkillDTO
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

        [HttpGet("category/{id}")]
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

        [HttpGet("categories")]
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

        [HttpGet("client")]
        public ActionResult<GeneralResponse> GetByClientId([FromQuery] int id)
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
                jobDTOs[i].categoryTitle = jobs[i].Category.Title;

                foreach (JobSkills jobSkill in jobs[i].skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(jobSkill.SkillId);

                    jobDTOs[i].skillsDTO.Add(new SkillDTO
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

        [HttpPost]
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

                foreach (SkillDTO skillDTO in jobDto.skillsDTO)
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

        [HttpPut]
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
            foreach (SkillDTO skillDto in jobDto.skillsDTO)
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

        [HttpDelete("{id:int}")]
        public ActionResult<GeneralResponse> delete(int id)
        {
            Job? job = _unitOfWork.jobRepository.GetById(id);

            if(job is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = id,
                    Message = $"No Job found with this ID : {id}",
                    Status = 404 ,
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
