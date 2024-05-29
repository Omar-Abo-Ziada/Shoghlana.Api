using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repositories;
using Shoghlana.Api.Response;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ClientController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
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

                }
                return Ok(new GeneralResponse
                {
                    IsSuccess = true,
                    Data = clientsDTO
                });
            }
            return NotFound(new GeneralResponse
            {
                IsSuccess = false,
                Message = "There is no Clients"
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Client client = unitOfWork.client.GetById(id);

            if (client != null)
            {

                GetClientDTO clientsDTO = new GetClientDTO();
                clientsDTO.Name = client.Name;
                clientsDTO.Image = client.Image;
                clientsDTO.Phone = client.Phone;
                clientsDTO.Description = client.Description;
                clientsDTO.Country = client.Country;

                return Ok(new GeneralResponse
                {
                    IsSuccess = true,
                    Data = clientsDTO
                });
            }
            return NotFound(new GeneralResponse
            {
                IsSuccess = false,
                Message = "Client Not Found"
            });
        }
        [HttpGet("jobs/{id}")]
        public IActionResult GetJobsByClientId(int id)
        {
            Client? client = unitOfWork.client.GetClientWithJobs(id);
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

                return Ok(new GeneralResponse
                {
                    IsSuccess = true,
                    Data = clientWithJobs
                });

            }
            return NotFound(new GeneralResponse
            {
                IsSuccess = false,
                Message = "Client not found"
            });

        }

        [HttpPost]
        public IActionResult CreateClient([FromForm] ClientDTO clientDTO)
        {
            using var dataStream = new MemoryStream();
            clientDTO.Image.CopyTo(dataStream);

            if (ModelState.IsValid)
            {//sd
                Client client = new Client();
                client.Name = clientDTO.Name;
                client.Image = dataStream.ToArray();
                client.Description = clientDTO.Description;
                client.Country = clientDTO.Country;
                client.Phone = clientDTO.Phone;
                unitOfWork.client.Add(client);
                unitOfWork.Save();
                return Ok(new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Client added successfully",
                    Data = clientDTO
                });
            }
            return BadRequest(new GeneralResponse
            {
                IsSuccess = false,
                Message = "Invalid client data"
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, [FromForm] ClientDTO clientDTO)
        {
            using var dataStream = new MemoryStream();
            clientDTO.Image.CopyTo(dataStream);
            Client existingClient = unitOfWork.client.GetById(id);
            if (existingClient == null)
            {
                return NotFound(new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Client Not found"
                });
            }
            existingClient.Name = clientDTO.Name;
            existingClient.Description = clientDTO.Description;
            existingClient.Country = clientDTO.Country;
            existingClient.Phone = clientDTO.Phone;
            existingClient.Image = dataStream.ToArray();
            unitOfWork.client.Update(existingClient);
            unitOfWork.Save();
            return Ok(new GeneralResponse
            {
                IsSuccess = true,
                Message = "Client updated",
                Data = clientDTO
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            Client existingClient = unitOfWork.client.GetById(id);
            if (existingClient == null)
            {
                return NotFound(new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Client Not found"
                });
            }

            unitOfWork.client.Delete(existingClient);
            unitOfWork.Save();
            return Ok(new GeneralResponse
            {
                IsSuccess = true,
                Message = "Client deleted"
            });
        }


    }
}
