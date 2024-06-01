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

                foreach (Skill skill in jobs[i].skills)
                {
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



        [HttpGet("Id")]
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

                foreach (Skill skill in job.skills)
                {
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

            foreach(SkillDTO skillDTO in jobDto.skillsDTO) 
            {
                Skill skill = unitOfWork.skill.GetById(skillDTO.Id);

                job.skills.Add(skill);
            }
            
            try
            {
                unitOfWork.job.Add(job);
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


            List<Skill> skills = new List<Skill>();
            foreach (SkillDTO skillDto in jobDto.skillsDTO)
            {
                Skill skill = unitOfWork.skill.GetById(skillDto.Id);
                skills.Add(skill);
            }
            job.skills = skills;

            List<JobSkills> jobSkills = unitOfWork.jobSkills
                                       .FindAll(criteria: j => j.JobId == jobDto.Id)
                                       .ToList();

            unitOfWork.jobSkills.DeleteRange(jobSkills);

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
    }
}
