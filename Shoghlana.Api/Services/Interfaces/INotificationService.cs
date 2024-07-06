using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Interfaces
{
    public interface INotificationService : IGenericService<Notification>
    {
        ActionResult<GeneralResponse> GetByFreelancerId(int FreelancerId);
        ActionResult<GeneralResponse> GetByClientId(int ClientId);



    }
}
