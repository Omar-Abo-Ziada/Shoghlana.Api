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
    public class ProjectRepository : GenericRepository<Project> , IProjectRepository
    {
        public ProjectRepository(ApplicationDBContext context) : base(context)
        {

        }
    }
}
