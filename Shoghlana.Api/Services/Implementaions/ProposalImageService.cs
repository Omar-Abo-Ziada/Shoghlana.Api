using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Implementaions
{
    public class ProposalImageService : GenericService<ProposalImages>, IProposalImageService
    {
        public ProposalImageService(IUnitOfWork unitOfWork, IGenericRepository<ProposalImages> genericRepository)
            : base(unitOfWork, genericRepository)
        {

        }
    }
}