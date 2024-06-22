using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.SignalR;
using Shoghlana.Api.Hubs;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Implementaions
{
    public class RateService : GenericService<Rate>, IRateService
    {
        private readonly IMapper mapper;
        private readonly IHubContext<NotificationHub> hubContext;

        public RateService(IUnitOfWork unitOfWork, IGenericRepository<Rate> repository, IMapper mapper, IHubContext<NotificationHub> hubContext)
            : base(unitOfWork, repository)
        {
            this.mapper = mapper;
            this.hubContext = hubContext;
        }

        public ActionResult<GeneralResponse> GetAll()
        {
            IEnumerable<Rate> rates = _unitOfWork.rateRepository.FindAll();
            if (rates != null)
            {
                List<RateDTO> ratesDTO = new List<RateDTO>();
                foreach (Rate rate in rates)
                {
                    RateDTO rateDTO = mapper.Map<RateDTO>(rate);
                    ratesDTO.Add(rateDTO);
                }

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 200,
                    Data = ratesDTO,
                };
            }
            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 400,
                Message = "There is no Rates",
            };
        }

        public ActionResult<GeneralResponse> GetById(int id)
        {
            Rate? rate = _unitOfWork.rateRepository.GetById(id);

            if (rate != null)
            {
                RateDTO rateDTO = mapper.Map<RateDTO>(rate);

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 200,
                    Data = rateDTO,
                };
            }
            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 400,
                Message = "Rate not found",
            };
        }

        public async Task<ActionResult<GeneralResponse>> CreateRate(RateDTO rateDTO)
        {
            Job? existingJob = _unitOfWork.jobRepository.GetById(rateDTO.JobId);

            if (existingJob is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 404,
                    Message = "Job not found"
                };
            }

            Rate rate = mapper.Map<Rate>(rateDTO);

            _unitOfWork.rateRepository.Add(rate);

            _unitOfWork.Save();

            if (existingJob.AcceptedFreelancerId.HasValue)
            {
                Client? client = _unitOfWork.clientRepository.GetById((int)existingJob.ClientId);

                if (client is not null)
                {
                    var notificationDto = new NotificationDTO
                    {
                        Title = " أضاف تقييم جديد للخدمة التي نفذتها",
                        sentTime = DateTime.Now,
                        description = existingJob.Title,
                        senderName = client.Name,
                        senderImage = client.Image
                    };

                    await NotifyFreelancer(existingJob.AcceptedFreelancerId.Value, notificationDto);
                }
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Data = rateDTO,
                Message = "Rate created successfully"
            };


        }

        private async Task NotifyFreelancer(int freelancerId, NotificationDTO notificationDto)
        {
            string connectionId = NotificationHub.GetUserConnectionId(freelancerId.ToString());
            if (!string.IsNullOrEmpty(connectionId))
            {
                await hubContext.Clients.Client(connectionId).SendAsync("ReceiveNotification", notificationDto);
            }
        }

        public async Task<ActionResult<GeneralResponse>> UpdateRate(int id, RateDTO rateDTO)
        {
            Rate? existingRate = _unitOfWork.rateRepository.GetById(id);

            if (existingRate != null)
            {
                mapper.Map(rateDTO, existingRate);

                _unitOfWork.rateRepository.Update(existingRate);

                _unitOfWork.Save();

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 200,
                    Data = rateDTO,
                    Message = "Rate updated successfully"
                };
            }
            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 400,
                Message = "Rate not found"
            };
        }

        public ActionResult<GeneralResponse> DeleteRate(int id)
        {
            Rate? existingRate = _unitOfWork.rateRepository.GetById(id);

            if (existingRate != null)
            {
                _unitOfWork.rateRepository.Delete(existingRate);

                _unitOfWork.Save();

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 200,
                    Message = "Rate deleted successfully"
                };
            }
            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 400,
                Message = "Rate not found"
            };
        }
    }
}