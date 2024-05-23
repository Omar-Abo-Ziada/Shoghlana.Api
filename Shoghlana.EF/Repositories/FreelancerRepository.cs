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
    public class FreelancerRepository : Repository<Freelancer> , IFreelancerRepository
    {
        public FreelancerRepository(ApplicationDBContext context) : base(context)
        {

        }
    }
}
