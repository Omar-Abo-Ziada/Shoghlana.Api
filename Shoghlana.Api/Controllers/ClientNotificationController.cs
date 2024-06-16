using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Shoghlana.Api.Hubs;
using Shoghlana.Core.Interfaces;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientNotificationController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHubContext<NotificationHub> hubContext;


        public ClientNotificationController(IUnitOfWork unitOfWork, IMapper mapper, IHubContext<NotificationHub> hubContext)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.hubContext = hubContext;
        }
    }
}
