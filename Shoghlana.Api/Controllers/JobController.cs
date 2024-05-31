using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.DTOs;
using Shoghlana.Api.Response;
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
            List<Job> jobs = unitOfWork.job.FindAll(new string[] { "Client" , "Category" }).ToList();

            List<JobDTO> jobDTOs = mapper.Map<List<Job> , List<JobDTO>>(jobs); 
            
            for(int i = 0; i<jobs.Count; i++)
            {
                jobDTOs[i].clientName = jobs[i].Client.Name; 
                jobDTOs[i].categoryTitle = jobs[i].Category.Title;
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
                job = unitOfWork.job.Find(new string[] { "Proposals" , "skills" , "Category" , "Client"});
                jobDTO = mapper.Map<Job, JobDTO>(job);
                foreach (Proposal proposal in job.Proposals)
                {
                    Freelancer freelancer = unitOfWork.freelancer.GetById(proposal.FreelancerId);
                    jobDTO.AppliedFreelancers.Add(freelancer);
                }
            }
            catch(Exception ex)
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
            return new GeneralResponse
            {
                IsSuccess = true,
                Data = jobDto,
                Message = "Job is added successfully"
            };
        }
    }
}
