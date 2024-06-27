using Microsoft.EntityFrameworkCore;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Enums;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repository;

namespace Shoghlana.EF.Repositories
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        private DateTime FiveDaysAgo = DateTime.Now.Subtract(TimeSpan.FromDays(5));
        public JobRepository(ApplicationDBContext context) : base(context)
        {

        }

        public PaginatedListDTO<Job> GetPaginatedJobs
           (JobStatus? status, int? MinBudget, int? MaxBudget, int? ClientId, int? FreelancerId, bool? HasManyProposals, bool? IsNew,
            int page, int pageSize, PaginatedJobsRequestBody requestBody)
        {
            IQueryable<Job> query = dbSet;

            if (status is not null && status != JobStatus.All)
            {
                query = query.Where(j => j.Status == status);
            }

            if (MinBudget > 0 && MinBudget is not null)
            {
                query = query.Where(j => j.MinBudget >= MinBudget);
            }

            if (MaxBudget > 0 && MaxBudget is not null)
            {
                query = query.Where(j => j.MaxBudget <= MaxBudget);
            }

            if (requestBody?.CategoriesIDs is not null && requestBody.CategoriesIDs.Any())
            {
                var validCategoriesIDs = requestBody.CategoriesIDs.Where(id => id > 0).ToList();

                if (validCategoriesIDs.Count > 0)
                {
                    query = query.Where(j => validCategoriesIDs.Contains((int)j.CategoryId));
                }
            }

            if (ClientId > 0 && ClientId is not null)
            {
                query = query.Where(j => j.ClientId == ClientId);
            }

            if (FreelancerId > 0 && FreelancerId is not null)
            {
                query = query.Where(j => j.AcceptedFreelancerId == FreelancerId);
            }

         

            if (requestBody?.Includes is not null && requestBody.Includes.Any())
            {
                foreach (var include in requestBody.Includes)
                {
                    if (include != "string")
                    {
                        query = query.Include(include);
                    }
                }
            }

            if (HasManyProposals is not null)
            {
                switch (HasManyProposals)
                {
                    case true:
                        query = query.Where(j => j.Proposals.Count() > 5);
                        break;
                    case false:
                        query = query.Where(j => j.Proposals.Count <= 5);
                        break;
                }
            }

            if (IsNew is not null)
            {
                switch (IsNew)
                {
                    case true:
                        query = query.Where(j => j.PostTime > FiveDaysAgo);   
                        break;
                    case false:
                        query = query.Where(j => j.PostTime < FiveDaysAgo);
                        break;
                }
            }


            int totalFilteredItems = query.Count();

            if (page < 1)
            {
                page = 1;
            }

            int totalPages = (int)Math.Ceiling(totalFilteredItems / (double)pageSize);

            if (page > totalPages)
            {
                page = totalPages;
            }

            if (totalPages == 0)
            {
                return new PaginatedListDTO<Job>
                {
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = 0,
                    Items = null
                };
            }

       



            var items = query.Skip((page - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

            return new PaginatedListDTO<Job>     
            {
                TotalItems = totalFilteredItems,
                TotalPages = totalPages,
                CurrentPage = page, 
                Items = items
            };
        }

        public async Task<PaginatedListDTO<Job>> GetPaginatedJobsAsync
      (JobStatus? status, int? MinBudget, int? MaxBudget, int? ClientId, int? FreelancerId, bool? HasManyProposals, bool? IsNew, int page, int pageSize, PaginatedJobsRequestBody requestBody)
        {
            IQueryable<Job> query = dbSet;

            if (status is not null && status != JobStatus.All)
            {
                query = query.Where(j => j.Status == status);
            }

            if (MinBudget > 0 && MinBudget is not null)
            {
                query = query.Where(j => j.MinBudget >= MinBudget);
            }

            if (MaxBudget > 0 && MaxBudget is not null)
            {
                query = query.Where(j => j.MaxBudget <= MaxBudget);
            }

            if (requestBody?.CategoriesIDs is not null && requestBody.CategoriesIDs.Any())
            {
                var validCategoriesIDs = requestBody.CategoriesIDs.Where(id => id > 0).ToList();

                if (validCategoriesIDs.Count > 0)
                {
                    query = query.Where(j => validCategoriesIDs.Contains((int)j.CategoryId));
                }
            }

            if (ClientId > 0 && ClientId is not null)
            {
                query = query.Where(j => j.ClientId == ClientId);
            }

            if (FreelancerId > 0 && FreelancerId is not null)
            {
                query = query.Where(j => j.AcceptedFreelancerId == FreelancerId);
            }

            if (requestBody?.Includes is not null && requestBody.Includes.Any())
            {
                foreach (var include in requestBody.Includes)
                {
                    if (include != "string")
                    {
                        query = query.Include(include);
                    }
                }
            }


            if (HasManyProposals is not null)
            {
                switch (HasManyProposals)
                {
                    case true:
                        query = query.Where(j => j.Proposals.Count() > 5);
                        break;
                    case false:
                        query = query.Where(j => j.Proposals.Count <= 5);
                        break;
                }
            }

            if (IsNew is not null)
            {
                switch (IsNew)
                {
                    case true:
                        query = query.Where(j => j.PostTime > FiveDaysAgo);
                        break;
                    case false:
                        query = query.Where(j => j.PostTime < FiveDaysAgo);
                        break;
                }
            }

            int totalFilteredItems = await query.CountAsync();

            if (page < 1)
            {
                page = 1;
            }

            int totalPages = (int)Math.Ceiling(totalFilteredItems / (double)pageSize);

            if (page > totalPages)
            {
                page = totalPages;
            }

            if (totalPages == 0)
            {
                return new PaginatedListDTO<Job>
                {
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = 0,
                    Items = null
                };
            }

            var items = await query.Skip((page - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();

            return new PaginatedListDTO<Job>
            {
                TotalItems = totalFilteredItems,
                TotalPages = totalPages,
                CurrentPage = page,
                Items = items
            };
        }


        public List<Job> GetByCategoryId(int id) 
        {
          List<Job> jobs = context.Jobs.Where(j => j.CategoryId == id)
                                  .ToList();

            return jobs;
        }
    }
}