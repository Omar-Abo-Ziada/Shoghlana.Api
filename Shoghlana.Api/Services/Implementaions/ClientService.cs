using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class ClientService : GenericService<Client> , IClientService
    {
        private List<string> allowedExtensions = new List<string>() { ".jpg", ".png", ".jpeg" };

        private long maxAllowedImageSize = 1_048_576;

        private readonly IHubContext<NotificationHub> hubContext;
        private readonly IMapper mapper;

        public ClientService(IUnitOfWork unitOfWork, IGenericRepository<Client> repository , IHubContext<NotificationHub> hubContext,
            IMapper mapper) : base(unitOfWork, repository)
        {
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        public ActionResult<GeneralResponse> GetAll()
        {
            IEnumerable<Client> clients = _unitOfWork.clientRepository.FindAll();

            if (clients != null)
            {
                List<GetClientDTO> clientsDTO = new List<GetClientDTO>();

                foreach (Client client in clients)
                {
                    GetClientDTO clientDTO = new GetClientDTO();
                    clientDTO.Id = client.Id;
                    clientDTO.Name = client.Name;
                    clientDTO.Image = client.Image;
                    clientDTO.Description = client.Description;
                    clientDTO.Phone = client.Phone;
                    clientDTO.Country = client.Country;

                    clientsDTO.Add(clientDTO);

                    var notificationDto = new NotificationDTO
                    {
                        Title = "New Client Registered",
                        description = $"{client.Name} has registered.",
                        sentTime = DateTime.Now,
                        senderName = client.Name,
                        senderImage = client.Image
                    };

                    hubContext.Clients.All.SendAsync("ReceiveNotification", notificationDto);
                }

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 200,
                    Data = clientsDTO,
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 400,
                Message = "There is no Clients"
            };
        }

        public ActionResult<GeneralResponse> GetById(int id)
        {
            //Client? client = _unitOfWork.clientRepository.GetById(id);
            Client? client = _unitOfWork.clientRepository.Find(criteria: c => c.Id == id, includes: new string[] { "Jobs" });


            if (client != null)
            {

                GetClientDTO clientsDTO = new GetClientDTO();
                clientsDTO.Name = client.Name;
                clientsDTO.Image = client.Image;
                clientsDTO.Phone = client.Phone;
                clientsDTO.Description = client.Description;
                clientsDTO.Country = client.Country;
                clientsDTO.JobsCount = client.JobsCount;
                clientsDTO.CompletedJobsCount = client.CompletedJobsCount;
                clientsDTO.Id = client.Id;
                clientsDTO.RegisterationTime = client.RegisterationTime;
                if (client?.Jobs?.Count > 0)
                {
                    foreach (Job job in client.Jobs)
                    {
                        AddJobDTO jobDTO = new AddJobDTO();
                        jobDTO = mapper.Map<Job, AddJobDTO>(job);
                        clientsDTO.Jobs.Add(jobDTO);
                    }
                }
             
                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 200,
                    Data = clientsDTO
                };
            }
            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 400,
                Message = "Client Not Found !"
            };
        }

        public ActionResult<GeneralResponse> GetJobsByClientId(int id)
        {
            Client? client = _unitOfWork.clientRepository.Find(includes: ["Jobs"], criteria: c => c.Id == id);

            if (client != null)
            {
                ClientWithJobsDTO clientWithJobs = new ClientWithJobsDTO();
                clientWithJobs.Name = client.Name;
                clientWithJobs.Image = client.Image;
                clientWithJobs.Jobs = client.Jobs.Select(job => new AddJobDTO
                {
                    Title = job.Title,
                    Description = job.Description,
                    PostTime = job.PostTime,
                    MaxBudget = job.MaxBudget,
                    MinBudget = job.MinBudget,
                }).ToList();

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 200,
                    Data = clientWithJobs
                };

            }
            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 400,
                Message = "Client Not Found !"
            };
        }

        public async Task<ActionResult<GeneralResponse>> CreateClient([FromForm] ClientDTO clientDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return new GeneralResponse()
            //    {
            //        IsSuccess = false,
            //        Status = 400,
            //        Data = ModelState,
            //        Message = "Invalid Model State!"
            //    };
            //}

            if (clientDTO.Image is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "Image is required!"
                };
            }

            if (!allowedExtensions.Contains(Path.GetExtension(clientDTO.Image.FileName).ToLower()))
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "Only JPG, PNG and Jpeg image formats are allowed!"
                };
            }

            if (clientDTO.Image.Length > maxAllowedImageSize)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "Image size exceeds the maximum allowed size (1 MB)!"
                };
            }

            using var dataStream = new MemoryStream();
            clientDTO.Image.CopyTo(dataStream);

            Client client = new Client()
            {
                Name = clientDTO.Name,
                Image = dataStream.ToArray(),
                Description = clientDTO.Description,
                Country = clientDTO.Country,
                Phone = clientDTO.Phone
            };

            _unitOfWork.clientRepository.Add(client);

            _unitOfWork.Save();

            // Send notification
            var notificationDto = new NotificationDTO
            {
                Title = "New Client Registered",
                description = $"{client.Name} has registered.",
                sentTime = DateTime.Now,
                senderName = client.Name,
                senderImage = client.Image
            };

            await hubContext.Clients.All.SendAsync("ReceiveNotification", notificationDto);  // todo why send notifi.. for all clients , for this client instead ??? 

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 201,
                Data = client,
                Message = "Client added successfully!"
            };
        }

        public async Task<ActionResult<GeneralResponse>> UpdateClient(ClientDTO clientDTO)
        {

            Client? existingClient = _unitOfWork.clientRepository.GetById(clientDTO.Id);

            if (existingClient == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "Client Not Found"
                };
            }

            if (clientDTO.Image is not null)
            {
                if (!allowedExtensions.Contains(Path.GetExtension(clientDTO.Image.FileName).ToLower()))
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Status = 400,
                        Message = "(Jpg , Png, Jpeg) يرجي استخدام ملف",
                        Data = GetById(clientDTO.Id)
                    };
                }

                if (clientDTO.Image.Length > maxAllowedImageSize)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Status = 400,
                        Message = "The max Allowed Image Size => 1 MB ",
                    };
                }

                using var dataStream = new MemoryStream();
                clientDTO.Image.CopyTo(dataStream);
                existingClient.Image = dataStream.ToArray();

                //return new GeneralResponse()
                //{
                //    IsSuccess = false,
                //    Status = 400,
                //    Message = "Image is required"
                //};
            }

           

          


            existingClient.Name = clientDTO.Name;
            existingClient.Description = clientDTO.Description;
            existingClient.Country = clientDTO.Country;
           // existingClient.Phone = clientDTO.Phone;

            _unitOfWork.clientRepository.Update(existingClient);

            _unitOfWork.Save();

            //return new GeneralResponse()
            //{
            //    IsSuccess = true,
            //    Status = 200,
            //    Data = clientDTO
            //};
            return GetById(clientDTO.Id);
        }

        public ActionResult<GeneralResponse> DeleteClient(int id)
        {
            Client? existingClient = _unitOfWork.clientRepository.GetById(id);

            if (existingClient == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "Client Not Found"
                };
            }

            _unitOfWork.clientRepository.Delete(existingClient);

            _unitOfWork.Save();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 204,
                Message = $"Client is deleted successfully !"
            };
        }

        public ActionResult<GeneralResponse> GetNotificationsByClientId(int clientId)
        {
            Client? client = _unitOfWork.clientRepository.Find(criteria: c => c.Id == clientId, includes: ["Notifications"]);

            if (client is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"Invalid client ID : {clientId}"
                };
            }

            if (client?.Notifications?.Count == 0)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 404,
                    Message = $"No Notifications found for this client: {clientId}"
                };
            }

            List<GetNotificationsDTO> clientNotificationsDTOs = new List<GetNotificationsDTO>();

            foreach (Notification notification in client.Notifications)
            {
                GetNotificationsDTO clientNotificationsDTO = mapper.Map<Notification, GetNotificationsDTO>(notification);

                clientNotificationsDTOs.Add(clientNotificationsDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = clientNotificationsDTOs,
                Message = $"Client with ID : {clientId} => All Notifications"
            };
        }

    }
}