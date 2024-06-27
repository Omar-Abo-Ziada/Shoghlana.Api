using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Enums;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")] // Apply Allow All policy now for testing
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


        [HttpPost("pagination")]
        public ActionResult<GeneralResponse> GetPaginatedJobs
          (int? MinBudget, int? MaxBudget, int? ClientId, int? FreelancerId , bool? HasManyProposals , bool? IsNew, int page = defaultPageNumber, int pageSize = defaultPageSize, JobStatus? status = JobStatus.All
            , PaginatedJobsRequestBody requestBody = null)
        {
            return jobService.GetPaginatedJobs(status, MinBudget, MaxBudget, ClientId, FreelancerId , HasManyProposals, IsNew, page, pageSize, requestBody);
        }

        [HttpPost("paginationAsync")]
        public Task<ActionResult<GeneralResponse>> GetPaginatedJobsAsync
          (int? MinBudget, int? MaxBudget, int? ClientId, int? FreelancerId, bool? HasManyProposals, bool? IsNew, int page = defaultPageNumber, int pageSize = defaultPageSize, JobStatus? status = JobStatus.All, PaginatedJobsRequestBody requestBody = null)
        {
            return jobService.GetPaginatedJobsAsync(status, MinBudget, MaxBudget, ClientId, FreelancerId, HasManyProposals, IsNew, page, pageSize, requestBody);
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
        public ActionResult<GeneralResponse> GetJobsByCategoryId([FromRoute] int id)
        {
            return jobService.GetJobsByCategoryId(id);
        }

        [HttpGet("categories")]
        public ActionResult<GeneralResponse> GetJobsByCategoryIds([FromQuery] List<int> ids)
        {
            return jobService.GetJobsByCategoryIds(ids);
        }

        [HttpGet("client/{id:int}")]
        public ActionResult<GeneralResponse> GetByClientId([FromRoute] int id)
        {
            return jobService.GetByClientId(id);
        }


        [HttpPost]
        public ActionResult<GeneralResponse> Add(AddJobDTO jobDto)
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
        public ActionResult<GeneralResponse> update(AddJobDTO jobDto)
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


        [HttpGet("Search")]
        public async Task <ActionResult<GeneralResponse>> SearchByJobTitleAsync(string KeyWord)
        {
            if(KeyWord == null || KeyWord == "")
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "No key word to use in search"
                };
            }
            return await jobService.SearchByJobTitleAsync(KeyWord);
        }
    }
}