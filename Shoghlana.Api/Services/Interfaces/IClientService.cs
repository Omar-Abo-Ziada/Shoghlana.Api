using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementaions;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Interfaces
{
    public interface IClientService : IGenericService<Client>
    {
        public ActionResult<GeneralResponse> GetAll();

        public ActionResult<GeneralResponse> GetById(int id);

        public ActionResult<GeneralResponse> GetJobsByClientId(int id);

        public Task<ActionResult<GeneralResponse>> CreateClient([FromForm] ClientDTO clientDTO);

        public  Task<ActionResult<GeneralResponse>> UpdateClient(ClientDTO clientDTO);

        public ActionResult<GeneralResponse> DeleteClient(int id);

       public ActionResult<GeneralResponse> GetNotificationsByClientId(int clientId);
    }
}