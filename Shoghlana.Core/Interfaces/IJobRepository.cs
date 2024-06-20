using Shoghlana.Core.DTO;
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
       (int MinBudget, int MaxBudget, int CategoryId, int ClientId, int FreelancerId,
        int page, int pageSize, string[] includes = null);

        public Task<PaginatedListDTO<Job>> GetPaginatedJobsAsync
        (int MinBudget, int MaxBudget, int CategoryId, int ClientId, int FreelancerId,
         int page, int pageSize, string[] includes = null);

    }
}
