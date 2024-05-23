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
    public class ProjectSkillsRepository : Repository<ProjectSkills> , IProjectSkillsRepository
    {
        public ProjectSkillsRepository(ApplicationDBContext context) : base(context)
        {

        }
    }
}
