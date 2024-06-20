using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Models;
using System.Linq.Expressions;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class JobController : ControllerBase
    {
        private readonly IJobService jobService;

        private const int defaultPageNumber = 1;

        private const int defaultPageSize = 5;

        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            return jobService.GetAll();
        }

        [HttpGet("pagination")]
        public ActionResult<GeneralResponse> GetPaginatedJobs
          (int MinBudget, int MaxBudget, int CategoryId, int ClientId, int FreelancerId ,int page = defaultPageNumber, int pageSize = defaultPageSize,string[] includes = null)
        {
            return jobService
             .GetPaginatedJobs(MinBudget, MaxBudget, CategoryId, ClientId, FreelancerId, page, pageSize, includes);
        }

        [HttpGet("paginationAsync")]
        public async Task<ActionResult<GeneralResponse>> GetPaginatedJobsAsync
          (int MinBudget, int MaxBudget, int CategoryId, int ClientId, int FreelancerId, int page = defaultPageNumber, int pageSize = defaultPageSize, string[] includes = null)
        {
            return await jobService.GetPaginatedJobsAsync(MinBudget, MaxBudget, CategoryId, ClientId, FreelancerId, page, pageSize, includes);
        }
            
        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> Get(int id)
        {
            return jobService.Get(id);
        }

        [HttpGet("freelancer/{id:int}")]
        public ActionResult<GeneralResponse> GetByFreelancerId(int id)
        {
            return jobService.GetByFreelancerId(id);
        }

        [HttpGet("category/{id:int}")]
        public ActionResult<GeneralResponse> GetJobsByCategoryId(int id)
        {
            return jobService.GetJobsByCategoryId(id);
        }

        [HttpGet("categories")]
        public ActionResult<GeneralResponse> GetJobsByCategoryIds([FromQuery] List<int> ids)
        {
            return jobService.GetJobsByCategoryIds(ids);
        }

        [HttpGet("client/{id:int}")]
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