using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public JobController(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }


        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Job> jobs = unitOfWork.job.FindAll(new string[] { "Client", "Category", "skills" }).ToList();

            List<JobDTO> jobDTOs = mapper.Map<List<Job>, List<JobDTO>>(jobs);

            for (int i = 0; i < jobs.Count; i++)
            {
                jobDTOs[i].clientName = jobs[i].Client.Name;
                jobDTOs[i].categoryTitle = jobs[i].Category.Title;

                foreach (JobSkills jobSkill in jobs[i].skills)
                {
                    Skill skill = unitOfWork.skill.GetById(jobSkill.SkillId);
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



        [HttpGet("{Id:int}")]
        public ActionResult<GeneralResponse> Get(int id)
        {
            Job job = new Job();
            JobDTO jobDTO = new JobDTO();
            try
            {
                job = unitOfWork.job.Find(j => j.Id == id , new string[] { "Proposals", "skills", "Category", "Client" });

                jobDTO = mapper.Map<Job, JobDTO>(job);
                jobDTO.clientName = job.Client.Name;
                jobDTO.categoryTitle = job.Category.Title;

                foreach (Proposal proposal in job.Proposals)
                {
                    Freelancer freelancer = unitOfWork.freelancer.GetById(proposal.FreelancerId);
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
                    
                  Skill skill = unitOfWork.skill.GetById(jobSkill.SkillId);
                     
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


        [HttpPost]
        public ActionResult<GeneralResponse> Add(JobDTO jobDto)
        {
            Job job = mapper.Map<JobDTO, Job>(jobDto);

            //foreach(SkillDTO skillDTO in jobDto.skillsDTO) 
            //{
            //    JobSkills skill = unitOfWork.jobSkills.Find(js => {js.SkillId == skillDTO.Id && js.JobId ==  });

            //    job.skills.Add(skill);
            //}
            
            try
            {
                unitOfWork.job.Add(job);
                unitOfWork.Save();

                foreach (SkillDTO skillDTO in jobDto.skillsDTO)
                {
                    job.skills.Add(new JobSkills
                    {
                        SkillId = skillDTO.Id,
                        JobId = job.Id
                    });
                } 
                unitOfWork.job.Update(job);
                unitOfWork.Save();
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
            Job job = unitOfWork.job.GetById(jobDto.Id);
            //  job = mapper.Map<JobDTO, Job>(jobDto);
            job.Description = jobDto.Description;
            job.Title = jobDto.Title;
            job.MaxBudget = jobDto.MaxBudget;
            job.MinBudget = jobDto.MinBudget;
            job.ExperienceLevel = jobDto.ExperienceLevel;
            job.CategoryId = jobDto.CategoryId;

            List<JobSkills> jobSkills = unitOfWork.jobSkills
                                   .FindAll(criteria: js => js.JobId == jobDto.Id)
                                   .ToList();
            unitOfWork.jobSkills.DeleteRange(jobSkills);

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
                    unitOfWork.job.Update(job);
                    unitOfWork.Save();
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
            Job job = unitOfWork.job.GetById(id);
            List<JobSkills> jobSkills = unitOfWork.jobSkills
                                       .FindAll(criteria: js => js.JobId == id)
                                       .ToList();

            if(jobSkills.Count > 0)
            {
                unitOfWork.jobSkills.DeleteRange(jobSkills);
            }


            List<Proposal> proposals = unitOfWork.proposal
                                      .FindAll(criteria: p => p.JobId == id)
                                      .ToList();

            if(proposals.Count > 0)
            {
                foreach (Proposal proposal in proposals)
                {
                    List<ProposalImages> images = unitOfWork.proposalImage
                                              .FindAll(criteria: pi => pi.ProposalId == proposal.Id)
                                              .ToList();

                    unitOfWork.proposalImage.DeleteRange(images);
                }

                unitOfWork.proposal.DeleteRange(proposals);
            }
           

            Rate rate = unitOfWork.rate.Find(criteria: r => r.JobId == id);
            if(rate != null)
            {
                unitOfWork.rate.Delete(rate);
            }

            try
            {
                unitOfWork.job.Delete(job);
                unitOfWork.Save();
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
