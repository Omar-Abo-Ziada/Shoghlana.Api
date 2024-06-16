using NuGet.Protocol.Core.Types;
using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repositories;

namespace Shoghlana.Api.Services.Implementaions
{
    public class ProposalService : GenericService<Proposal>, IProposalService
    {
        public ProposalService(IUnitOfWork unitOfWork, IGenericRepository<Proposal> repository)
           : base(unitOfWork, repository)
        {
        }

        // Override generic methods if needed
        public override async Task<Proposal> GetByIdAsync(int id)
        {
            // Custom implementation for Proposal
            return await base.GetByIdAsync(id);
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            return await _unitOfWork.jobRepository.GetByIdAsync(id);
        }

        public async Task<Freelancer> GetFreelancerByIdAsync(int id)
        {
            return await _unitOfWork.freelancerRepository.GetByIdAsync(id);
        }

        // Add any entity-specific methods here if needed
    }
}