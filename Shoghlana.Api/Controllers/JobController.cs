using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class JobController : ControllerBase
    {
        private readonly IJobService jobService;
        private readonly IMapper mapper;

        public JobController(IJobService jobService, IMapper _mapper)
        {
            this.jobService = jobService;
            mapper = _mapper;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            return jobService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> Get(int id)
        {
            return jobService.Get(id);
        }

        [HttpGet("freelancer")]
        public ActionResult<GeneralResponse> GetByFreelancerId([FromQuery] int id)
        {
            return jobService.GetByFreelancerId(id);
        }

        [HttpGet("category/{id}")]
        public ActionResult<GeneralResponse> GetJobsByCategoryId(int id)
        {
            return jobService.GetJobsByCategoryId(id);
        }

        [HttpGet("categories")]
        public ActionResult<GeneralResponse> GetJobsByCategoryIds([FromQuery] List<int> ids)
        {
            return jobService.GetJobsByCategoryIds(ids);
        }

        [HttpGet("client")]
        public ActionResult<GeneralResponse> GetByClientId([FromQuery] int id)
        {
            return jobService.GetByClientId(id);
        }

        [HttpPost]
        public ActionResult<GeneralResponse> Add(JobDTO jobDto)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Data = ModelState,
                    Message = "Invalid Model State !"
                };
            }

            return jobService.Add(jobDto);
        }

        [HttpPut]
        public ActionResult<GeneralResponse> update(JobDTO jobDto)
        {

            if (!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Data = ModelState,
                    Message = "Invalid Model State !"
                };
            }

            return jobService.update(jobDto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<GeneralResponse> delete(int id)
        {
           return jobService.delete(id);
        }
    }
}