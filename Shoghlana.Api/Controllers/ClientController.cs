using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Shoghlana.Api.Hubs;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            return clientService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            return clientService.GetById(id);
        }

        [HttpGet("jobs/{id}")]
        public ActionResult<GeneralResponse> GetJobsByClientId(int id)
        {
            return clientService.GetJobsByClientId(id);
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> CreateClient([FromForm] ClientDTO clientDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Data = ModelState,
                    Message = "Invalid Model State!"
                };
            }

            return await clientService.CreateClient(clientDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GeneralResponse>> UpdateClient(int id, [FromForm] ClientDTO clientDTO)
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

            return await clientService.UpdateClient(id, clientDTO);
        }


        [HttpDelete("{id}")]
        public ActionResult<GeneralResponse> DeleteClient(int id)
        {
            return clientService.DeleteClient(id);
        }
    }
}