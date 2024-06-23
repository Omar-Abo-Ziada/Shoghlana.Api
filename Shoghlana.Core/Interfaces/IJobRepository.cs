using Shoghlana.Core.DTO;
using Shoghlana.Core.Enums;
using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Interfaces
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        public PaginatedListDTO<Job> GetPaginatedJobs
       (JobStatus? status, int? MinBudget, int? MaxBudget, int? ClientId, int? FreelancerId, bool? HasManyProposals, bool? IsNew,
            int page, int pageSize, PaginatedJobsRequestBody requestBody);

        public Task<PaginatedListDTO<Job>> GetPaginatedJobsAsync
       (JobStatus? status, int? MinBudget, int? MaxBudget, int? ClientId, int? FreelancerId, bool? HasManyProposals, bool? IsNew, int page, int pageSize, PaginatedJobsRequestBody requestBody);
    }
}
