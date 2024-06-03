using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Shoghlana.Api.Hubs;
using Shoghlana.Api.Response;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHubContext<NotificationHub> hubContext;

        public RateController(IUnitOfWork unitOfWork, IMapper mapper, IHubContext<NotificationHub> hubContext)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.hubContext = hubContext;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            IEnumerable<Rate> rates = unitOfWork.rate.GetAll();
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

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            Rate rate = unitOfWork.rate.GetById(id);
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

        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> CreateRate(RateDTO rateDTO)
        {
            if (ModelState.IsValid)
            {
                Job existingJob = unitOfWork.job.GetById(rateDTO.JobId);
                if (existingJob == null)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Status = 400,
                        Message = "Job not found"
                    };
                }

                Rate rate = mapper.Map<Rate>(rateDTO);
                unitOfWork.rate.Add(rate);
                unitOfWork.Save();

                if (existingJob.FreelancerId.HasValue)
                {
                    Client client = unitOfWork.client.GetById(existingJob.ClientId.Value);
                    if (client != null)
                    {
                        var notificationDto = new NotificationDTO
                        {
                            Title = " أضاف تقييم جديد للخدمة التي نفذتها",
                            sentTime = DateTime.Now,
                            description = existingJob.Title,
                            senderName = client.Name,
                            senderImage = client.Image
                        };

                        await NotifyFreelancer(existingJob.FreelancerId.Value, notificationDto);
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

            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 400,
                Message = "Invalid rate data"
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

        [HttpPut("{id}")]
        public async Task<ActionResult<GeneralResponse>> UpdateRate(int id, RateDTO rateDTO)
        {
            if (ModelState.IsValid)
            {
                Rate existingRate = unitOfWork.rate.GetById(id);
                if (existingRate != null)
                {
                    mapper.Map(rateDTO, existingRate);
                    unitOfWork.rate.Update(existingRate);
                    unitOfWork.Save();

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
            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 400,
                Message = "Invalid rate data"
            };
        }

        [HttpDelete("{id}")]
        public ActionResult<GeneralResponse> DeleteRate(int id)
        {
            Rate existingRate = unitOfWork.rate.GetById(id);
            if (existingRate != null)
            {
                unitOfWork.rate.Delete(existingRate);
                unitOfWork.Save();

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
