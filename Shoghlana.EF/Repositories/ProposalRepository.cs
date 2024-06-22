using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repository;

namespace Shoghlana.EF.Repositories
{
    public class ProposalRepository : GenericRepository<Proposal> , IProposalRepository
    {
        public ProposalRepository(ApplicationDBContext context) : base(context)
        {

        }
    }
}