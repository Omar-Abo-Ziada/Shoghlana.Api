using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public JobController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Job> jobs = unitOfWork.job.FindAll(j => j.Id == j.Id , new string[] {""} ).ToList(); 
            return new GeneralResponse
            {
                IsSuccess = true,
                Data = jobs,
                Message = "All jobs retrieved successfully"
            };
        }

        [HttpGet("Id")]
        public ActionResult<GeneralResponse> Get(int id) 
        {
           Job job = new Job();
            try
            {
                job = unitOfWork.job.GetById(id);
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
                Data = job,
                Message = "Job is retrieved successfully"
            };
        }
    }
}
