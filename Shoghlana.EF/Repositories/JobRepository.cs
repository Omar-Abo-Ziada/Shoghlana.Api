using Microsoft.EntityFrameworkCore;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
           (int MinBudget, int MaxBudget, int CategoryId, int ClientId, int FreelancerId,
            int page, int pageSize, string[] includes = null)
        {
            IQueryable<Job> query = dbSet;

            if (MinBudget > 0)
            {
                query = query.Where(j => j.MinBudget >= MinBudget);
            }

            if (MaxBudget > 0)
            {
                query = query.Where(j => j.MaxBudget <= MaxBudget);
            }

            if (CategoryId > 0)
            {
                query = query.Where(j => j.CategoryId == CategoryId);
            }

            if (ClientId > 0)
            {
                query = query.Where(j => j.ClientId == ClientId);
            }

            if (FreelancerId > 0)
            {
                query = query.Where(j => j.FreelancerId == FreelancerId);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            int totalFilteredItems = query.Count();

            if (page < 1)
            {
                page = 1;
            }

            int totalPages = (int)Math.Ceiling(totalFilteredItems / (double)pageSize);

            //if (page > totalPages)
            //{
            //    page = totalPages;
            //}

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
        (int MinBudget, int MaxBudget, int CategoryId, int ClientId, int FreelancerId,
         int page, int pageSize, string[] includes = null)
        {
            IQueryable<Job> query = dbSet;

            if (MinBudget > 0)
            {
                query = query.Where(j => j.MinBudget >= MinBudget);
            }

            if (MaxBudget > 0)
            {
                query = query.Where(j => j.MaxBudget <= MaxBudget);
            }

            if (CategoryId > 0)
            {
                query = query.Where(j => j.CategoryId == CategoryId);
            }

            if (ClientId > 0)
            {
                query = query.Where(j => j.ClientId == ClientId);
            }

            if (FreelancerId > 0)
            {
                query = query.Where(j => j.FreelancerId == FreelancerId);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
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

            if (page == 0)
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