using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Core.DTO;
using Shoghlana.Api.Response;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly IUnitOfWork unitOfWork;

        public ProposalController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        //****************************************************************

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Proposal> proposals = unitOfWork.proposal.GetAll().ToList();

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
            Proposal? proposal = unitOfWork.proposal.GetById(id);

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
        public ActionResult<GeneralResponse> GetByJobId(int id)
        {
            List<Proposal> proposals = unitOfWork.proposal.GetAll().ToList();

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

        //[HttpPost]
        //public async Task<ActionResult<GeneralResponse>> AddAsync([FromForm] AddFreelancerDTO addedFreelancerDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return new GeneralResponse()
        //        {
        //            IsSuccess = false,
        //            Status = 400,
        //            Data = ModelState,
        //            Message = "Invalid Model State !"
        //        };
        //    }

        //    if (addedFreelancerDTO.PersonalImageBytes is null)
        //    {
        //        return new GeneralResponse()
        //        {
        //            IsSuccess = false,
        //            Status = 400,
        //            Message = "Personal Image is required"
        //        };
        //    }

        //    if (!allowedExtensions.Contains(Path.GetExtension(addedFreelancerDTO.PersonalImageBytes.FileName).ToLower()))
        //    {
        //        return new GeneralResponse()
        //        {
        //            IsSuccess = false,
        //            Status = 400,
        //            Message = "The allowed Personal Image Extensions => {jpg , png}",
        //        };
        //    }

        //    if (addedFreelancerDTO.PersonalImageBytes.Length > maxAllowedPersonalImageSize)
        //    {
        //        return new GeneralResponse()
        //        {
        //            IsSuccess = false,
        //            Status = 400,
        //            Message = "The max Allowed Personal Image Size => 1 MB ",
        //        };
        //    }

        //    using var dataStream = new MemoryStream();

        //    await addedFreelancerDTO.PersonalImageBytes.CopyToAsync(dataStream);

        //    Freelancer freelancer = new Freelancer()
        //    {
        //        Name = addedFreelancerDTO.Name,
        //        Title = addedFreelancerDTO.Title,
        //        Address = addedFreelancerDTO.Address,
        //        Overview = addedFreelancerDTO.Overview,
        //        PersonalImageBytes = dataStream.ToArray(),
        //    };

        //    Freelancer addedFreelancer = await unitOfWork.freelancer.AddAsync(freelancer);

        //    unitOfWork.Save();

        //    FreelancerDTO freelancerDTO = mapper.Map<Freelancer, FreelancerDTO>(freelancer);

        //    return new GeneralResponse()
        //    {
        //        IsSuccess = true,
        //        Status = 201,
        //        Data = freelancerDTO,
        //        Message = "Added Successfully"
        //    };
        //    //freelancer = mapper.Map<FreelancerDTO, Freelancer>(freelancerDTO);
        //}

        //[HttpPut("{id:int}")]
        //public async Task<ActionResult<GeneralResponse>> UpdateAsync(int id, [FromForm] AddFreelancerDTO addedFreelancerDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return new GeneralResponse()
        //        {
        //            IsSuccess = false,
        //            Status = 400,
        //            Data = ModelState,
        //            Message = "Invalid Model State !"
        //        };
        //    }

        //    Freelancer? freelancer = unitOfWork.freelancer.GetById(id);

        //    if (freelancer is null)
        //    {
        //        return new GeneralResponse()
        //        {
        //            IsSuccess = false,
        //            Status = 400,
        //            Message = "There is no Freelancer found with this ID !"
        //        };
        //    }

        //    if (addedFreelancerDTO.PersonalImageBytes != null)
        //    {
        //        if (!allowedExtensions.Contains(Path.GetExtension(addedFreelancerDTO.PersonalImageBytes.FileName).ToLower()))
        //        {
        //            return new GeneralResponse()
        //            {
        //                IsSuccess = false,
        //                Status = 400,
        //                Message = "The allowed Personal Image Extensions => {jpg , png}",
        //            };
        //        }

        //        if (addedFreelancerDTO.PersonalImageBytes.Length > maxAllowedPersonalImageSize)
        //        {
        //            return new GeneralResponse()
        //            {
        //                IsSuccess = false,
        //                Status = 400,
        //                Message = "The max Allowed Personal Image Size => 1 MB ",
        //            };
        //        }

        //        using var dataStream = new MemoryStream();

        //        await addedFreelancerDTO.PersonalImageBytes.CopyToAsync(dataStream);

        //        freelancer.PersonalImageBytes = dataStream.ToArray();
        //    }

        //    freelancer.Name = addedFreelancerDTO.Name;
        //    freelancer.Title = addedFreelancerDTO.Title;
        //    freelancer.Overview = addedFreelancerDTO.Overview;
        //    freelancer.Address = addedFreelancerDTO.Address;

        //    unitOfWork.Save();

        //    FreelancerDTO freelancerDTO = mapper.Map<Freelancer, FreelancerDTO>(freelancer);

        //    return new GeneralResponse()
        //    {
        //        IsSuccess = true,
        //        Status = 200,
        //        Data = freelancerDTO
        //    };
        //}

        //[HttpDelete("{id:int}")]
        //public ActionResult<GeneralResponse> Delete(int id)
        //{
        //    Freelancer? freelancer = unitOfWork.freelancer.GetById(id);

        //    if (freelancer is null)
        //    {
        //        return new GeneralResponse()
        //        {
        //            IsSuccess = false,
        //            Status = 400,
        //            Message = "There is no Freelancer found with this ID !"
        //        };
        //    }

        //    unitOfWork.freelancer.Delete(freelancer);

        //    unitOfWork.Save();

        //    return new GeneralResponse()
        //    {
        //        IsSuccess = true,
        //        Status = 204, // no content
        //        Message = $"The Freelancer with ID ({freelancer.Id}) is deleted successfully !"
        //    };
        //}

    }
}
