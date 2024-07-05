using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.Core.Enums;

namespace Shoghlana.Api.Services.Implementaions
{
    public class ProposalService : GenericService<Proposal>, IProposalService
    {
        private readonly IMapper mapper;

        private List<string> allowedExtensions = new List<string>() { ".jpg", ".png", "jpeg" };

        private long maxAllowedPersonalImageSize = 1_048_576;  // 1 MB = 1024 * 1024 bytes

        public ProposalService(IUnitOfWork unitOfWork, IGenericRepository<Proposal> repository, IMapper mapper)
           : base(unitOfWork, repository)
        {
            this.mapper = mapper;
        }

        public async Task<ActionResult<GeneralResponse>> GetAll()
        {
            List<Proposal> proposals = _unitOfWork.proposalRepository.FindAll(includes: ["Images"]).ToList();


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

        public ActionResult<GeneralResponse> GetById(int id)
        {
            Proposal? proposal = _unitOfWork.proposalRepository.GetById(id);

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

        public async Task<ActionResult<GeneralResponse>> GetByJobId(int id)
        {
            Job? job = await _unitOfWork.jobRepository.GetByIdAsync(id);

            if (job is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 404,
                    Message = "There are no Job found with this ID ."
                };
            }

            List<Proposal> proposals = _unitOfWork.proposalRepository.FindAll(includes: ["Freelancer"], criteria: p => p.JobId == id).ToList();

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
                getProposalDTO.FreelancerName = proposal.Freelancer.Name;

                getProposalDTOs.Add(getProposalDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Data = getProposalDTOs,
            };
        }

        public async Task<ActionResult<GeneralResponse>> GetByFreelancerId(int id)
        {
            Freelancer? freelancer = await _unitOfWork.freelancerRepository.GetByIdAsync(id);

            if (freelancer is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 404,
                    Message = $"There are no freelancer found with this ID {id} ."
                };
            }

            List<Proposal> proposals = _unitOfWork.proposalRepository.FindAll(includes: null, criteria: p => p.FreelancerId == id).ToList();

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
                Job? job = _unitOfWork.jobRepository.Find(j => j.Id == proposal.JobId, ["Client"]);

                GetProposalDTO getProposalDTO = mapper.Map<Proposal, GetProposalDTO>(proposal);
                getProposalDTO.JobTitle = job?.Title;
                getProposalDTO.ClientName = job?.Client.Name;
                getProposalDTOs.Add(getProposalDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Data = getProposalDTOs,
            };
        }

        public async Task<ActionResult<GeneralResponse>> AddAsync([FromForm] AddProposalDTO addProposalDTO)
        {

            Job? job = await _unitOfWork.jobRepository.GetByIdAsync(addProposalDTO.JobId);

            if (job is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"No job found with this ID: {addProposalDTO.JobId}!"
                };
            }

            Freelancer? freelancer = await _unitOfWork.freelancerRepository.GetByIdAsync(addProposalDTO.FreelancerId);

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

                Proposal addedProposal = await _unitOfWork.proposalRepository.AddAsync(proposal);

                _unitOfWork.Save();

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

                Proposal addedProposal = await _unitOfWork.proposalRepository.AddAsync(proposal);

                _unitOfWork.Save();

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
        public async Task<ActionResult<GeneralResponse>> UpdateAsync(int id, [FromForm] AddProposalDTO addProposalDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return new GeneralResponse()
            //    {
            //        IsSuccess = false,
            //        Status = 400,
            //        Data = ModelState,
            //        Message = "Invalid Model State !"
            //    };
            //}

            Proposal? proposal = _unitOfWork.proposalRepository.Find(includes: ["Images"], criteria: p => p.Id == id);

            if (proposal is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"No Proposal found with this ID: {id}!"
                };
            }

            Job? job = await _unitOfWork.jobRepository.GetByIdAsync(addProposalDTO.JobId);

            if (job is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"No job found with this ID: {addProposalDTO.JobId}!"
                };
            }

            Freelancer? freelancer = await _unitOfWork.freelancerRepository.GetByIdAsync(addProposalDTO.FreelancerId);

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

                    _unitOfWork.proposalImageRepository.Delete(image);
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

                _unitOfWork.Save();

                Proposal? editedProposal = _unitOfWork.proposalRepository.Find(includes: ["Images"], criteria: p => p.Id == proposal.Id);

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

                _unitOfWork.Save();

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

        public ActionResult<GeneralResponse> Delete(int id)
        {
            Proposal? proposal = _unitOfWork.proposalRepository.Find(includes: ["Images"], criteria: p => p.Id == id);

            if (proposal == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"No Proposal Found With this ID {id} ! ",
                };
            }

            _unitOfWork.proposalRepository.Delete(proposal);

            _unitOfWork.Save();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 204, // no content
                Message = $"The Proposal with ID ({proposal.Id}) is deleted successfully !"
            };
        }

        public ActionResult<GeneralResponse> AcceptProposal(int proposalId)
        {
            Proposal? proposal = _unitOfWork.proposalRepository.GetById(proposalId);

            if (proposal is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"Invalid Proposal ID : {proposalId}"
                };
            }

            proposal.ApprovedTime = DateTime.Now;
            proposal.DeadLine = DateTime.Now.AddDays(proposal.Duration);
            proposal.Status = ProposalStatus.Approved;

            //--------------------------------------------------------

            Job? job = _unitOfWork.jobRepository.GetById(proposal.JobId);

            if (job is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"Invalid job ID : {proposal.JobId}"
                };
            }

            job.ApproveTime = DateTime.Now;
            job.Status = JobStatus.Closed;  
            job.AcceptedFreelancerId = proposal.FreelancerId;

            //--------------------------------------------------------

            Freelancer? freelancer = _unitOfWork.freelancerRepository.Find(criteria: f => f.Id == proposal.FreelancerId, includes: ["Notifications"]);

            if (freelancer is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"Invalid freelancer ID : {proposal.FreelancerId}"
                };
            }

            FreelancerNotification freelancerNotification = new FreelancerNotification()
            {
                FreelancerId = proposal.FreelancerId,
                Title = "Proposal Accepted: Congratulations!",
                sentTime = DateTime.Now,
                description = $"Your proposal for {job.Title} has been accepted by the client. Get ready to start the project!",
                //Reason = NotificationReason.AcceptedProposal,
                //NotificationTriggerId = job.Id 
            };

            _unitOfWork.freelancerNotificationRepository.Add(freelancerNotification);

            //_unitOfWork.Save();


            //--------------------------------------------------------

            Client? client = _unitOfWork.clientRepository.Find(criteria: c => c.Id == job.ClientId, includes: ["Notifications"]);

            if (client is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = $"Invalid client ID : {job.ClientId}"
                };
            }

            ClientNotification clientNotification = new ClientNotification()
            {
                ClientId = job.ClientId,
                Title = "Freelancer Accepted Proposal",
                sentTime = DateTime.Now,
                description = $"Congratulations , You successfully Accepted The freelancer {freelancer.Name} proposal for {job.Title}. You can now proceed with the next steps.",
                //Reason = NotificationReason.AcceptedProposal,
                //NotificationTriggerId = job.Id
            };

            _unitOfWork.clientNotificationRepository.Add(clientNotification);

            //--------------------------------------------------------

            _unitOfWork.Save();

            return new GeneralResponse
            {
                IsSuccess = true,
                Message = $"The client {job.ClientId} Accepted the proposal {proposalId} from freelancer {job.AcceptedFreelancerId} on job {job.Id} successfully"
            };
        }
    }
}