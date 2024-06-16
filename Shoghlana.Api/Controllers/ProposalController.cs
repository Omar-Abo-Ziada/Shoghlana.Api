using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Core.DTO;
using Shoghlana.Api.Response;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.Api.Services.Interfaces;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private readonly IProposalService proposalService;

        public ProposalController(IProposalService proposalService, IProposalImageService proposalImageService)
        {
            this.proposalService = proposalService;
        }

        //****************************************************************

        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> GetAll()
        {
            return await proposalService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            return proposalService.GetById(id);
        }

        [HttpGet("GetByJobId/{id:int}")]
        public async Task<ActionResult<GeneralResponse>> GetByJobId(int id)
        {
            return await proposalService.GetByJobId(id);
        }

        [HttpGet("GetByFreelancerId/{id:int}")]
        public async Task<ActionResult<GeneralResponse>> GetByFreelancerId(int id)
        {
            return await proposalService.GetByFreelancerId(id);
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> AddAsync([FromForm] AddProposalDTO addProposalDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Data = ModelState,
                    Message = "Invalid Model State !"
                };
            }

            return await proposalService.AddAsync(addProposalDTO);
        }

        // TODO : Try To use Async in Find to reduce waiting time
        [HttpPut("{id:int}")]
        public async Task<ActionResult<GeneralResponse>> Update(int id, [FromForm] AddProposalDTO addProposalDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Data = ModelState,
                    Message = "Invalid Model State !"
                };
            }

            return await proposalService.UpdateAsync(id, addProposalDTO);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<GeneralResponse> Delete(int id)
        {
           return proposalService.Delete(id);
        }
    }
}