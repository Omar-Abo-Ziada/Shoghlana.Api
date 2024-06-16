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
        private List<string> allowedExtensions = new List<string>() { ".jpg", ".png" };

        private long maxAllowedImageSize = 1_048_576;

        private readonly IHubContext<NotificationHub> hubContext;

        public ClientService(IUnitOfWork unitOfWork, IGenericRepository<Client> repository , IHubContext<NotificationHub> hubContext) : base(unitOfWork, repository)
        {
            this.hubContext = hubContext;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            IEnumerable<Client> clients = _unitOfWork.clientRepository.FindAll();

            if (clients != null)
            {
                List<GetClientDTO> clientsDTO = new List<GetClientDTO>();

                foreach (Client client in clients)
                {
                    GetClientDTO clientDTO = new GetClientDTO();

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

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            Client? client = _unitOfWork.clientRepository.GetById(id);

            if (client != null)
            {

                GetClientDTO clientsDTO = new GetClientDTO();
                clientsDTO.Name = client.Name;
                clientsDTO.Image = client.Image;
                clientsDTO.Phone = client.Phone;
                clientsDTO.Description = client.Description;
                clientsDTO.Country = client.Country;
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

        [HttpGet("jobs/{id}")]
        public ActionResult<GeneralResponse> GetJobsByClientId(int id)
        {
            Client? client = _unitOfWork.clientRepository.Find(includes: ["Jobs"], criteria: c => c.Id == id);

            if (client != null)
            {
                ClientWithJobsDTO clientWithJobs = new ClientWithJobsDTO();
                clientWithJobs.Name = client.Name;
                clientWithJobs.Image = client.Image;
                clientWithJobs.Jobs = client.Jobs.Select(job => new JobDTO
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

        [HttpPost]
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
                    Message = "Only JPG and PNG image formats are allowed!"
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

            await hubContext.Clients.All.SendAsync("ReceiveNotification", notificationDto);

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 201,
                Data = client,
                Message = "Client added successfully!"
            };
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GeneralResponse>> UpdateClient(int id, [FromForm] ClientDTO clientDTO)
        {
            if (clientDTO.Image is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "Image is required"
                };
            }

            if (!allowedExtensions.Contains(Path.GetExtension(clientDTO.Image.FileName).ToLower()))
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "The allowed Image Extensions => {jpg , png}",
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

            existingClient.Name = clientDTO.Name;
            existingClient.Description = clientDTO.Description;
            existingClient.Country = clientDTO.Country;
            existingClient.Phone = clientDTO.Phone;
            existingClient.Image = dataStream.ToArray();

            _unitOfWork.clientRepository.Update(existingClient);

            _unitOfWork.Save();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Data = clientDTO
            };
        }


        [HttpDelete("{id}")]
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
    }
}