using Microsoft.EntityFrameworkCore;
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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDBContext context) : base(context) 
        {
            
        }

        public Category? GetCategorytWithJobs(int id)
        {
            return context.Categories
                .Include(x => x.Jobs)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
