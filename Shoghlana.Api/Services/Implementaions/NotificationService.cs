using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.DTO;

namespace Shoghlana.Api.Services.Implementaions
{
    public class NotificationService : GenericService<Notification> , INotificationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NotificationService(IUnitOfWork _unitOfWork , IGenericRepository<Notification> repository, IMapper mapper)
            : base(_unitOfWork , repository)
        {
            unitOfWork = _unitOfWork;
            this.mapper = mapper;
        }


        public ActionResult <GeneralResponse> GetByFreelancerId(int FreelancerId) 
        {
            List<Notification> Notifications = _unitOfWork.NotificationRepository
                                               .FindAll(criteria: n => n.FreelancerId == FreelancerId)
                                               .OrderByDescending(n => n.sentTime)
                                               .ToList();

            if(Notifications.Any())
            {
                List<GetNotificationsDTO> NotificationsDTO =
                    mapper.Map<List<GetNotificationsDTO>>(Notifications);

                foreach (Notification notification in Notifications)
                {
                    notification.IsRead = true;
                }
                _unitOfWork.NotificationRepository.save();

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = NotificationsDTO,
                    Message = "Notifications for this freelancer were retrieved successfully"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = false,
                Data = null,
                Message = "No found Notifications for this freelancer"
            };

        }



        public ActionResult <GeneralResponse> GetByClientId(int ClientId) 
        {
            List<Notification> Notifications = _unitOfWork.NotificationRepository
                                               .FindAll(criteria: n => n.ClientId == ClientId)
                                               .OrderByDescending(n => n.sentTime)
                                               .ToList();



            if (Notifications.Any())
            {
                List<GetNotificationsDTO> NotificationsDTO =
                    mapper.Map<List<GetNotificationsDTO>>(Notifications);

                foreach(Notification notification in Notifications)
                {
                    notification.IsRead = true;
                }
                _unitOfWork.NotificationRepository.save();

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = NotificationsDTO,
                    Message = "Notifications for this client were retrieved successfully"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = false,
                Data = null,
                Message = "No found Notifications for this client"
            };

        }
    }
}
