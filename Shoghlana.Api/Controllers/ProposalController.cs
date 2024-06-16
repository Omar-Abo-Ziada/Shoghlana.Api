using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Core.DTO;
using Shoghlana.Api.Response;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.Api.Services.Interfaces;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly IProposalService proposalService;
        private readonly IProposalImageService proposalImageService;
        private List<string> allowedExtensions = new List<string>() { ".jpg", ".png" };

        private long maxAllowedPersonalImageSize = 1_048_576;  // 1 MB = 1024 * 1024 bytes

        public ProposalController(IMapper mapper, IProposalService proposalService , IProposalImageService proposalImageService )
        {
            this.mapper = mapper;

            this.proposalService = proposalService;
            this.proposalImageService = proposalImageService;
        }

        //****************************************************************

        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> GetAll()
        {
            List<Proposal> proposals = proposalService.FindAll(includes: ["Images"]).ToList();


            List<GetProposalDTO> getProposalDTOs = new List<GetProposalDTO>(proposals.Count);

            foreach (Proposal proposal in proposals)
            {
                GetProposalDTO getProposalDTO = mapper.Map<Proposal, GetProposalDTO>(proposal);

                getProposalDTOs.Add(getProposalDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Data = getProposalDTOs,
            };
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            Proposal? proposal = proposalService.GetById(id);

            if (proposal is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400, // bad request
                    Message = "There is no Proposal found with this ID !"
                };
            }

            GetProposalDTO getProposalDTO = mapper.Map<Proposal, GetProposalDTO>(proposal);

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Data = getProposalDTO
            };
        }

        [HttpGet("GetByJobId/{id:int}")]
        public async Task<ActionResult<GeneralResponse>> GetByJobId(int id)
        {
            Job job = await proposalService.GetJobByIdAsync(id);

            if (job is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 404,
                    Message = "There are no Job found with this ID ."
                };
            }

            List<Proposal> proposals = proposalService.FindAll(includes: null, criteria: p => p.JobId == id).ToList();

            if (proposals.Count == 0)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 404,
                    Message = "There are no proposals yet to this job ."
                };
            }

            List<GetProposalDTO> getProposalDTOs = new List<GetProposalDTO>(proposals.Count);

            foreach (Proposal proposal in proposals)
            {
                GetProposalDTO getProposalDTO = mapper.Map<Proposal, GetProposalDTO>(proposal);

                getProposalDTOs.Add(getProposalDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Data = getProposalDTOs,
            };
        }

        [HttpGet("GetByFreelancerId/{id:int}")]
        public async Task<ActionResult<GeneralResponse>> GetByFreelancerId(int id)
        {
            Freelancer freelancer = await proposalService.GetFreelancerByIdAsync(id);

            if (freelancer is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 404,
                    Message = $"There are no freelancer found with this ID {id} ."
                };
            }

            List<Proposal> proposals = proposalService.FindAll(includes: null, criteria: p => p.FreelancerId == id).ToList();

            if (proposals.Count == 0)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 404,
                    Message = "There are no proposals yet to this freelancer ."
                };
            }

            List<GetProposalDTO> getProposalDTOs = new List<GetProposalDTO>(proposals.Count);

            foreach (Proposal proposal in proposals)
            {
                GetProposalDTO getProposalDTO = mapper.Map<Proposal, GetProposalDTO>(proposal);

                getProposalDTOs.Add(getProposalDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Data = getProposalDTOs,
            };
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> AddAsync([FromForm] AddProposalDTO addProposalDTO)
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

            Job job = await proposalService.GetJobByIdAsync(addProposalDTO.JobId);

            if (job is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"No job found with this ID: {addProposalDTO.JobId}!"
                };
            }

            Freelancer freelancer = await proposalService.GetFreelancerByIdAsync(addProposalDTO.FreelancerId);

            if (freelancer is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"No freelancer found with this ID: {addProposalDTO.FreelancerId}!"
                };
            }

            if (addProposalDTO.Images is not null && addProposalDTO.Images.Count > 0)
            {

                List<ProposalImages> proposalImages = new List<ProposalImages>();

                foreach (AddProposalImageDTO addProposalImageDTO in addProposalDTO.Images)
                {
                    if (!allowedExtensions.Contains(Path.GetExtension(addProposalImageDTO.Image.FileName).ToLower()))
                    {
                        return new GeneralResponse()
                        {
                            IsSuccess = false,
                            Status = 400,
                            Message = "The allowed Image Extensions => {jpg , png}",
                        };
                    }

                    if (addProposalImageDTO.Image.Length > maxAllowedPersonalImageSize)
                    {
                        return new GeneralResponse()
                        {
                            IsSuccess = false,
                            Status = 400,
                            Message = "The max Allowed Image Size => 1 MB ",
                        };
                    }

                    using var dataStream = new MemoryStream();

                    await addProposalImageDTO.Image.CopyToAsync(dataStream);

                    ProposalImages proposalImage = new ProposalImages()
                    {
                        //Id = addProposalImageDTO.Id,
                        Image = dataStream.ToArray(),
                        //ProposalId = addProposalImageDTO.ProposalId,
                    };

                    proposalImages.Add(proposalImage);
                }

                Proposal proposal = new Proposal()
                {
                    Images = proposalImages,

                    Duration = addProposalDTO.Duration,

                    Description = addProposalDTO.Description,

                    ReposLinks = addProposalDTO.ReposLinks,

                    FreelancerId = addProposalDTO.FreelancerId,

                    JobId = addProposalDTO.JobId,
                };

                //proposal = mapper.Map<AddProposalDTO, Proposal>(addProposalDTO);

                Proposal addedProposal = await proposalService.AddAsync(proposal);

                proposalService.Save();

                GetProposalDTO getProposalDTO = mapper.Map<Proposal, GetProposalDTO>(addedProposal);

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 201,
                    Data = getProposalDTO,
                    Message = "Proposal Added Successfully"
                };
            }
            else
            {
                Proposal proposal = new Proposal()
                {
                    Description = addProposalDTO.Description,

                    Duration = addProposalDTO.Duration,

                    Price = addProposalDTO.Price,

                    FreelancerId = addProposalDTO.FreelancerId,

                    JobId = addProposalDTO.JobId,

                    ReposLinks = addProposalDTO.ReposLinks,

                    Images = null,
                };

                //proposal = mapper.Map<AddProposalDTO, Proposal>(addProposalDTO);

                Proposal addedProposal = await proposalService.AddAsync(proposal);

                proposalService.Save();

                GetProposalDTO getProposalDTO = mapper.Map<Proposal, GetProposalDTO>(proposal);

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 201,
                    Data = getProposalDTO,
                    Message = "Proposal Added Successfully"
                };
            }
        }

        // TODO : Try To use Async in Find to reduce waiting time
        [HttpPut("{id:int}")]
        public async Task<ActionResult<GeneralResponse>> Update(int id, [FromForm] AddProposalDTO addProposalDTO)
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

            Proposal proposal = proposalService.Find(includes: ["Images"], criteria: p => p.Id == id);

            if (proposal is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"No Proposal found with this ID: {id}!"
                };
            }

            Job job = await proposalService.GetJobByIdAsync(addProposalDTO.JobId);

            if (job is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"No job found with this ID: {addProposalDTO.JobId}!"
                };
            }

            Freelancer freelancer = await proposalService.GetFreelancerByIdAsync(addProposalDTO.FreelancerId);

            if (freelancer is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"No freelancer found with this ID: {addProposalDTO.FreelancerId}!"
                };
            }

            if (proposal.Images is not null || proposal?.Images?.Count > 0)
            {
                foreach (var image in proposal.Images)
                {
                    image.ProposalId = null;

                    proposalImageService.Delete(image);
                }
            }

            if (addProposalDTO.Images is not null && addProposalDTO.Images.Count > 0)
            {
                //Proposal validProposal = proposalService.Find(includes: ["Images"], criteria: p => p.Id == id);

                //foreach (var image in validProposal.Images)
                //{
                //    image.ProposalId = null;

                //    proposalServiceImages.Delete(image);
                //}

                List<ProposalImages> proposalImages = new List<ProposalImages>();

                foreach (AddProposalImageDTO addProposalImageDTO in addProposalDTO.Images)
                {
                    if (!allowedExtensions.Contains(Path.GetExtension(addProposalImageDTO.Image.FileName).ToLower()))
                    {
                        return new GeneralResponse()
                        {
                            IsSuccess = false,
                            Status = 400,
                            Message = "The allowed Image Extensions => {jpg , png}",
                        };
                    }

                    if (addProposalImageDTO.Image.Length > maxAllowedPersonalImageSize)
                    {
                        return new GeneralResponse()
                        {
                            IsSuccess = false,
                            Status = 400,
                            Message = "The max Allowed Image Size => 1 MB ",
                        };
                    }

                    using var dataStream = new MemoryStream();

                    await addProposalImageDTO.Image.CopyToAsync(dataStream);

                    ProposalImages proposalImage = new ProposalImages()
                    {
                        //Id = addProposalImageDTO.Id,
                        Image = dataStream.ToArray(),
                        //ProposalId = addProposalImageDTO.ProposalId,
                    };

                    proposalImages.Add(proposalImage);
                }

                proposal.Images = proposalImages;

                proposal.Duration = addProposalDTO.Duration;

                proposal.Description = addProposalDTO.Description;

                proposal.ReposLinks = addProposalDTO.ReposLinks;

                proposal.FreelancerId = addProposalDTO.FreelancerId;

                proposal.JobId = addProposalDTO.JobId;

                proposal.Price = addProposalDTO.Price;

                //proposal = mapper.Map<AddProposalDTO, Proposal>(addProposalDTO);

                proposalService.Save();

                Proposal editedProposal = proposalService.Find(includes: ["Images"], criteria: p => p.Id == proposal.Id);

                GetProposalDTO getProposalDTO = mapper.Map<Proposal, GetProposalDTO>(editedProposal);

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 201,
                    Data = getProposalDTO,
                    Message = "Proposal Added Successfully"
                };
            }
            else
            {

                proposal.Description = addProposalDTO.Description;
                proposal.Duration = addProposalDTO.Duration;
                proposal.Price = addProposalDTO.Price;
                proposal.FreelancerId = addProposalDTO.FreelancerId;
                proposal.JobId = addProposalDTO.JobId;
                proposal.ReposLinks = addProposalDTO.ReposLinks;
                proposal.Images = null;

                //proposal = mapper.Map<AddProposalDTO, Proposal>(addProposalDTO);

                //Proposal editedProposal = await proposalService.AddAsync(proposal);

                proposalService.Save();

                GetProposalDTO getProposalDTO = mapper.Map<Proposal, GetProposalDTO>(proposal);

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 201,
                    Data = getProposalDTO,
                    Message = "Proposal Added Successfully"
                };
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<GeneralResponse> Delete(int id)
        {
            Proposal proposal = proposalService.Find(includes: ["Images"], criteria: p => p.Id == id);

            if (proposal == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"No Proposal Found With this ID {id} ! ",
                };
            }

            proposalService.Delete(proposal);

            proposalService.Save();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 204, // no content
                Message = $"The Proposal with ID ({proposal.Id}) is deleted successfully !"
            };
        }
    }
}