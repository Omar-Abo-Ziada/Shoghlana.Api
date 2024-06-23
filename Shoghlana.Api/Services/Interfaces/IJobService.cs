using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementaions;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Enums;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repositories;
using System.Drawing.Printing;
using System.Linq.Expressions;

namespace Shoghlana.Api.Services.Interfaces
{
    public interface IJobService : IGenericService<Job>
    {
        public ActionResult<GeneralResponse> GetAll();

        public ActionResult<GeneralResponse> GetPaginatedJobs
        (JobStatus? status , int? MinBudget, int? MaxBudget, int? ClientId, int? FreelancerId, bool? HasManyProposals, bool? IsNew , int page, int pageSize, PaginatedJobsRequestBody requestBody);

        public Task<ActionResult<GeneralResponse>> GetPaginatedJobsAsync
        (JobStatus? status, int? MinBudget, int? MaxBudget, int? ClientId, int? FreelancerId,bool? HasManyProposals, bool? IsNew, int page, int pageSize, PaginatedJobsRequestBody requestBody);

        public ActionResult<GeneralResponse> Get(int id);

        public ActionResult<GeneralResponse> GetByFreelancerId([FromQuery] int id);

        public ActionResult<GeneralResponse> GetJobsByCategoryId(int id);

        public ActionResult<GeneralResponse> GetJobsByCategoryIds([FromQuery] List<int> ids);

        public ActionResult<GeneralResponse> GetByClientId([FromQuery] int id);

        public ActionResult<GeneralResponse> Add(AddJobDTO jobDto);

        public ActionResult<GeneralResponse> update(AddJobDTO jobDto);

        public ActionResult<GeneralResponse> delete(int id);
    }
}