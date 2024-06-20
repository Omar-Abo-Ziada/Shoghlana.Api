using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Implementaions
{
    public class FreelancerService : GenericService<Freelancer>, IFreelancerService
    {
        private readonly IMapper mapper;

        private List<string> allowedExtensions = new List<string>() { ".jpg", ".png" };

        private long maxAllowedPersonalImageSize = 1_048_576;  // 1 MB = 1024 * 1024 bytes

        public FreelancerService(IUnitOfWork unitOfWork, IGenericRepository<Freelancer> repository , IMapper mapper) 
            : base(unitOfWork, repository)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Freelancer> freelancers = _unitOfWork.freelancerRepository.FindAll(includes: ["Skills"]).ToList();

            List<FreelancerDTO> freelancerDTOs = new List<FreelancerDTO>(freelancers.Count);

            foreach (Freelancer freelancer in freelancers)
            {
                FreelancerDTO freelancerDTO = mapper.Map<Freelancer, FreelancerDTO>(freelancer);

                freelancerDTOs.Add(freelancerDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Data = freelancerDTOs,
            };
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            Freelancer? freelancer = _unitOfWork.freelancerRepository.Find(criteria: null, includes: ["Skills"]);

            if (freelancer is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400, // bad request
                    Message = "There is no Freelancer found with this ID !"
                };
            }

            FreelancerDTO freelancerDTO = mapper.Map<Freelancer, FreelancerDTO>(freelancer);

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Data = freelancerDTO
            };
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> AddAsync( AddFreelancerDTO addedFreelancerDTO)
        {
            Freelancer freelancer;
            if (addedFreelancerDTO.PersonalImageBytes is not null)
            {
                //return new GeneralResponse()
                //{
                //    IsSuccess = false,
                //    Status = 400,
                //    Message = "Personal Image is required"
                //};

                if (!allowedExtensions.Contains(Path.GetExtension(addedFreelancerDTO.PersonalImageBytes.FileName).ToLower()))
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Status = 400,
                        Message = "The allowed Personal Image Extensions => {jpg , png}",
                    };
                }

                if (addedFreelancerDTO.PersonalImageBytes.Length > maxAllowedPersonalImageSize)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Status = 400,
                        Message = "The max Allowed Personal Image Size => 1 MB ",
                    };
                }

                using var dataStream = new MemoryStream();

                await addedFreelancerDTO.PersonalImageBytes.CopyToAsync(dataStream);

                freelancer = new Freelancer()
                {
                    Name = addedFreelancerDTO.Name,
                    Title = addedFreelancerDTO.Title,
                    Address = addedFreelancerDTO.Address,
                    Overview = addedFreelancerDTO.Overview,
                    PersonalImageBytes = dataStream?.ToArray(),
                };
            }

            freelancer = new Freelancer()
            {
                Name = addedFreelancerDTO.Name,
                Title = addedFreelancerDTO.Title,
                Address = addedFreelancerDTO.Address,
                Overview = addedFreelancerDTO.Overview,
            };



            Freelancer addedFreelancer = await _unitOfWork.freelancerRepository.AddAsync(freelancer);

            _unitOfWork.Save();

            FreelancerDTO freelancerDTO = mapper.Map<Freelancer, FreelancerDTO>(freelancer);

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 201,
                Data = freelancerDTO,
                Message = "Added Successfully"
            };
            //freelancer = mapper.Map<FreelancerDTO, Freelancer>(freelancerDTO);
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult<GeneralResponse>> UpdateAsync(int id, [FromForm] AddFreelancerDTO addedFreelancerDTO)
        {
            Freelancer? freelancer = _unitOfWork.freelancerRepository.GetById(id);

            if (freelancer is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 404,
                    Message = "There is no Freelancer found with this ID !"
                };
            }

            if (addedFreelancerDTO.PersonalImageBytes != null)
            {
                if (!allowedExtensions.Contains(Path.GetExtension(addedFreelancerDTO.PersonalImageBytes.FileName).ToLower()))
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Status = 400,
                        Message = "The allowed Personal Image Extensions => {jpg , png}",
                    };
                }

                if (addedFreelancerDTO.PersonalImageBytes.Length > maxAllowedPersonalImageSize)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Status = 400,
                        Message = "The max Allowed Personal Image Size => 1 MB ",
                    };
                }

                using var dataStream = new MemoryStream();

                await addedFreelancerDTO.PersonalImageBytes.CopyToAsync(dataStream);

                freelancer.PersonalImageBytes = dataStream.ToArray();
            }

            #region Don't use Automapper here
            // can't use update here because the same instance is already tracked when I got him by Id
            // so I just map with my self and save changes => also cant use automapper because it creates a new instance and doesn't modify the existed one 
            // so SaveChanges won't take effect unless I Mapped manually 
            #endregion

            freelancer.Title = addedFreelancerDTO.Title;
            freelancer.Overview = addedFreelancerDTO.Overview;
            freelancer.Address = addedFreelancerDTO.Address;

            _unitOfWork.Save();

            FreelancerDTO freelancerDTO = mapper.Map<Freelancer, FreelancerDTO>(freelancer);

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Data = freelancerDTO
            };
        }

        [HttpDelete("{id:int}")]
        public ActionResult<GeneralResponse> Delete(int id)
        {
            Freelancer? freelancer = _unitOfWork.freelancerRepository.GetById(id);

            if (freelancer is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "There is no Freelancer found with this ID !"
                };
            }

            _unitOfWork.freelancerRepository.Delete(freelancer);

            _unitOfWork.Save();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 204, // no content
                Message = $"The Freelancer with ID ({freelancer.Id}) is deleted successfully !"
            };
        }
    }
}