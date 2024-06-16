using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Implementaions
{
    public class FreelancerService : GenericService<Freelancer>, IFreelancerService
    {
        public FreelancerService(IUnitOfWork unitOfWork, IGenericRepository<Freelancer> repository) 
            : base(unitOfWork, repository)
        {
        }
    }
}