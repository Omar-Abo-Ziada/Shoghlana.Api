using Microsoft.EntityFrameworkCore;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Enums;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.EF.Repositories
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(ApplicationDBContext context) : base(context)
        {

        }

        public PaginatedListDTO<Job> GetPaginatedJobs
           (JobStatus? status, int? MinBudget, int? MaxBudget, int? ClientId, int? FreelancerId, int page, int pageSize, PaginatedJobsRequestBody requestBody)
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
                query = query.Where(j => j.FreelancerId == FreelancerId);
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
      (JobStatus? status, int? MinBudget, int? MaxBudget, int? ClientId, int? FreelancerId, int page, int pageSize, PaginatedJobsRequestBody requestBody)
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
                query = query.Where(j => j.FreelancerId == FreelancerId);
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
    }
}