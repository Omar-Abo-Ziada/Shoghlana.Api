using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repositories;
using Shoghlana.Api.Response;
using Microsoft.AspNetCore.SignalR;
using Shoghlana.Api.Hubs;
using AutoMapper;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private List<string> allowedExtensions = new List<string>() { ".jpg", ".png" };

        private long maxAllowedImageSize = 1_048_576;
        private readonly IHubContext<NotificationHub> hubContext;
        private readonly IMapper mapper;

        public ClientController(IUnitOfWork unitOfWork, IHubContext<NotificationHub> hubContext, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            IEnumerable<Client> clients = unitOfWork.client.GetAll();


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

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            Client client = unitOfWork.client.Find(criteria: c => c.Id == id , includes: new string[] { "Jobs" }); 

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
                if(client?.Jobs?.Count > 0)
                {
                    foreach (Job job in client.Jobs)
                    {
                        JobDTO jobDTO = new JobDTO();
                        jobDTO = mapper.Map<Job,JobDTO>(job);
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
        [HttpGet("jobs/{id}")]
        public ActionResult<GeneralResponse> GetJobsByClientId(int id)
        {
            Client client = unitOfWork.client.GetClientWithJobs(id);
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

            unitOfWork.client.Add(client);
            unitOfWork.Save();

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

            Client existingClient = unitOfWork.client.GetById(id);
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

            unitOfWork.client.Update(existingClient);
            unitOfWork.Save();

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
            Client existingClient = unitOfWork.client.GetById(id);
            if (existingClient == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "Client Not Found"
                };
            }

            unitOfWork.client.Delete(existingClient);
            unitOfWork.Save();
            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 204,
                Message = $"Client is deleted successfully !"
            };
        }


    }
}
