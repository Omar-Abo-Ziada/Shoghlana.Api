using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Shoghlana.Api.Hubs;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.Interfaces;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHubContext<NotificationHub> hubContext;
        private readonly INotificationService notificationService;

        public NotificationController(IUnitOfWork unitOfWork, IMapper mapper, IHubContext<NotificationHub> hubContext,
            INotificationService NotificationService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.hubContext = hubContext;
            this.notificationService = NotificationService;
        }


        [HttpGet("FreelancerId/{id:int}")]
        public ActionResult<GeneralResponse> GetByFreelancerId(int id)
        {
            return notificationService.GetByFreelancerId(id);
        }

        [HttpGet("ClientId/{id:int}")]
        public ActionResult<GeneralResponse> GetByClientId(int id)
        {
            return notificationService.GetByClientId(id); 
        }

      
    }
}
