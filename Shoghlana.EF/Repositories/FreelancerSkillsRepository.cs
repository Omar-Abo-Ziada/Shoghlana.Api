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
    public class FreelancerSkillsRepository : GenericRepository<FreelancerSkills>, IFreelancerSkillsRepository
    {
        public FreelancerSkillsRepository(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}
