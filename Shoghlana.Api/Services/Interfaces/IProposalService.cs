using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Interfaces
{
    public interface IProposalService : IGenericService<Proposal>
    {
        public Task<ActionResult<GeneralResponse>> GetAll();

        public ActionResult<GeneralResponse> GetById(int id);

        public Task<ActionResult<GeneralResponse>> GetByJobId(int id);

        public Task<ActionResult<GeneralResponse>> GetByFreelancerId(int id);

        public Task<ActionResult<GeneralResponse>> AddAsync([FromForm] AddProposalDTO addProposalDTO);

        // TODO : Try To use Async in Find to reduce waiting time
        public Task<ActionResult<GeneralResponse>> UpdateAsync(int id, [FromForm] AddProposalDTO addProposalDTO);

        public ActionResult<GeneralResponse> Delete(int id);

       public ActionResult<GeneralResponse> AcceptProposal(int proposalId);
        ActionResult<GeneralResponse> RejectProposal(int proposalId);

    }
}