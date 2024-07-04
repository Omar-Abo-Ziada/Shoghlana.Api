using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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

        public ActionResult<GeneralResponse> GetAll()
        {
            List<Freelancer> freelancers = _unitOfWork.freelancerRepository
                                    .FindAll(includes: new[] { "Skills.Skill", "Portfolio", "WorkingHistory" }).ToList();

            List<GetFreelancerDTO> freelancerDTOs = freelancers.Select(freelancer =>
            {
                // Mapping skills
                List<Skill> Skills = new List<Skill>();
                foreach (FreelancerSkills FreelancerSkill in freelancer.Skills)
                {
                    Skill? skill = _unitOfWork.skillRepository.GetById(FreelancerSkill.SkillId);
                    Skills.Add(skill);
                }
                List<SkillDTO> SkillsDtos = mapper.Map<List<Skill>, List<SkillDTO>>(Skills);

                // Mapping portfolio projects and their skills
                List<GetProjectDTO> getProjectsDTOs = mapper.Map<List<Project>, List<GetProjectDTO>>(freelancer.Portfolio);
                for (int i = 0; i < freelancer.Portfolio.Count; i++)
                {
                    List<int> ProjectSkillsIds = _unitOfWork.projectSkillsRepository
                                                .FindAll(criteria: ps => ps.ProjectId == freelancer.Portfolio[i].Id)
                                                .Select(ps => ps.SkillId).ToList();

                    List<Skill> ProjectSkills = new List<Skill>();
                    foreach (int skillId in ProjectSkillsIds)
                    {
                        Skill skill = _unitOfWork.skillRepository.GetById(skillId);
                        ProjectSkills.Add(skill);
                    }

                    List<SkillDTO> skillDTOs = mapper.Map<List<Skill>, List<SkillDTO>>(ProjectSkills);
                    getProjectsDTOs[i].Skills = skillDTOs;
                }

                // Mapping working history and their rates
                List<GetJobDTO> jobDTOs = new List<GetJobDTO>();
                foreach (Job job in freelancer.WorkingHistory)
                {
                    GetJobDTO jobDto = mapper.Map<Job, GetJobDTO>(job);
                    Rate? rate = _unitOfWork.rateRepository.Find(r => r.JobId == job.Id);
                    RateDTO rateDto = mapper.Map<Rate, RateDTO>(rate);
                    jobDto.Rate = rateDto;
                    Category category = _unitOfWork.categoryRepository.GetById(job.CategoryId);
                    jobDto.CategoryTitle = category.Title;
                    jobDTOs.Add(jobDto);
                }

                // Mapping freelancer details
                return new GetFreelancerDTO
                {
                    Id = freelancer.Id,
                    Name = freelancer.Name,
                    Title = freelancer.Title,
                    Address = freelancer.Address,
                    Overview = freelancer.Overview,
                    PersonalImageBytes = freelancer.PersonalImageBytes,
                    skills = SkillsDtos,
                    Portfolio = getProjectsDTOs,
                    WorkingHistory = jobDTOs
                };
            }).ToList();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Data = freelancerDTOs,
            };
        }


        public ActionResult<GeneralResponse> GetById(int id)
        {
            Freelancer? freelancer = _unitOfWork.freelancerRepository
                                     .Find(criteria: f => f.Id == id, includes: ["Skills", "Portfolio", "WorkingHistory"]);

            if (freelancer is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400, // bad request
                    Message = "There is no Freelancer found with this ID !"
                };
            }

            //FreelancerDTO freelancerDTO = mapper.Map<Freelancer, FreelancerDTO>(freelancer);
            GetFreelancerDTO GetFreelancerDTO = new GetFreelancerDTO()
            {
                Id = freelancer.Id,
                Name = freelancer.Name,
                Address = freelancer.Address,
                Overview = freelancer.Overview,
                PersonalImageBytes = freelancer.PersonalImageBytes,
                Title = freelancer.Title
            };

            List<Skill> Skills = new List<Skill>();
            foreach(FreelancerSkills FreelancerSkill in freelancer.Skills)
            {
              Skill? skill = _unitOfWork.skillRepository.GetById(FreelancerSkill.SkillId);
                Skills.Add(skill);
            } 
            List<SkillDTO> SkillsDtos = mapper.Map<List<Skill>, List<SkillDTO>>(Skills);
            GetFreelancerDTO.skills = SkillsDtos;

            List<GetProjectDTO> getProjectsDTOs = new List<GetProjectDTO>();
            getProjectsDTOs = mapper.Map <List<Project> , List<GetProjectDTO>> (freelancer.Portfolio);


            for(int i = 0; i < freelancer.Portfolio.Count; i++)
            {
                List<int> ProjectSkillsIds = _unitOfWork.projectSkillsRepository
                                            .FindAll(criteria: ps => ps.ProjectId == freelancer.Portfolio[i].Id)
                                            .Select(ps => ps.SkillId).ToList();

                List<Skill> ProjectSkills = new List<Skill>();
                foreach(int skillId in ProjectSkillsIds)
                {
                    Skill skill = _unitOfWork.skillRepository.GetById(skillId);
                    ProjectSkills.Add(skill);
                }

                List<SkillDTO> skillDTOs = mapper.Map<List<Skill>, List<SkillDTO>>(ProjectSkills);
                getProjectsDTOs[i].Skills = skillDTOs;
            }
           
            GetFreelancerDTO.Portfolio = getProjectsDTOs;


            List<GetJobDTO> jobDTOs = new List<GetJobDTO>();
            foreach(Job job in freelancer.WorkingHistory)
            {
                GetJobDTO jobDto = mapper.Map<Job, GetJobDTO>(job);
                Rate? rate = _unitOfWork.rateRepository.Find(r => r.JobId == job.Id);
                RateDTO rateDto = mapper.Map<Rate, RateDTO>(rate);
                jobDto.Rate = rateDto;
                Category category = _unitOfWork.categoryRepository.GetById(job.CategoryId);
                jobDto.CategoryTitle = category.Title;
                jobDTOs.Add(jobDto);
            }
            GetFreelancerDTO.WorkingHistory = jobDTOs;

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Data = GetFreelancerDTO 
            };
        }

        public async Task<ActionResult<GeneralResponse>> AddAsync(AddFreelancerDTO addedFreelancerDTO)
        {
            if (addedFreelancerDTO.PersonalImageBytes != null)
            {
                // Validation for personal image
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
            }

            Freelancer freelancer = new Freelancer()
            {
                Name = addedFreelancerDTO.Name,
                Title = addedFreelancerDTO.Title,
                Address = addedFreelancerDTO.Address,
                Overview = addedFreelancerDTO.Overview
            };

            if (addedFreelancerDTO.PersonalImageBytes != null)
            {
                using var dataStream = new MemoryStream();
                await addedFreelancerDTO.PersonalImageBytes.CopyToAsync(dataStream);
                freelancer.PersonalImageBytes = dataStream.ToArray();
            }

            await _unitOfWork.freelancerRepository.AddAsync(freelancer);
            await _unitOfWork.SaveAsync(); // Ensure the freelancer gets an ID

            List<Skill> skills = (await _unitOfWork.skillRepository.FindAllAsync(criteria: s => addedFreelancerDTO.SkillIDs.Contains(s.Id))).ToList();

            List<FreelancerSkills> freelancerSkills = new List<FreelancerSkills>();

            foreach (var skill in skills)
            {
                FreelancerSkills freelancerSkill = new FreelancerSkills()
                {
                    SkillId = skill.Id,
                    FreelancerId = freelancer.Id // Assuming freelancer is already retrieved or available
                };

                freelancerSkills.Add(freelancerSkill);
            }

            // Assuming freelancer is already retrieved or available
            freelancer.Skills = freelancerSkills;

            _unitOfWork.freelancerRepository.Update(freelancer);
            await _unitOfWork.SaveAsync();

            //FreelancerDTO freelancerDTO = mapper.Map<Freelancer, FreelancerDTO>(freelancer);

            return new GeneralResponse
            {
                IsSuccess = true,
                Status = 201,
                Data = null,
                Message = "Added Successfully"
            };
        }

        public async Task<ActionResult<GeneralResponse>> UpdateAsync(int id, [FromForm] AddFreelancerDTO updatedFreelancerDTO)
        {
            Freelancer? freelancer = await _unitOfWork.freelancerRepository.GetByIdAsync(id);

            if (freelancer is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 404,
                    Message = "There is no Freelancer found with this ID!"
                };
            }

            if (updatedFreelancerDTO.PersonalImageBytes != null)
            {
                // Validation for personal image
                if (!allowedExtensions.Contains(Path.GetExtension(updatedFreelancerDTO.PersonalImageBytes.FileName).ToLower()))
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Status = 400,
                        Message = "The allowed Personal Image Extensions are: jpg, png",
                    };
                }

                if (updatedFreelancerDTO.PersonalImageBytes.Length > maxAllowedPersonalImageSize)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Status = 400,
                        Message = "The max allowed Personal Image size is 1 MB",
                    };
                }

                using var dataStream = new MemoryStream();
                await updatedFreelancerDTO.PersonalImageBytes.CopyToAsync(dataStream);
                freelancer.PersonalImageBytes = dataStream.ToArray();
            }

            freelancer.Name = updatedFreelancerDTO.Name;
            freelancer.Title = updatedFreelancerDTO.Title;
            freelancer.Address = updatedFreelancerDTO.Address;
            freelancer.Overview = updatedFreelancerDTO.Overview;

            if (updatedFreelancerDTO.SkillIDs != null && updatedFreelancerDTO.SkillIDs.Any())
            {
                IEnumerable<FreelancerSkills> oldFreelancerSkills = await _unitOfWork.freelancerSkillsRepository.FindAllAsync(criteria: fs => fs.FreelancerId == freelancer.Id);
                _unitOfWork.freelancerSkillsRepository.DeleteRange(oldFreelancerSkills);

                List<Skill> skills = (await _unitOfWork.skillRepository.FindAllAsync(criteria: s => updatedFreelancerDTO.SkillIDs.Contains(s.Id))).ToList();

                List<FreelancerSkills> newFreelancerSkills = new List<FreelancerSkills>(skills.Count);

                foreach (var skill in skills)
                {
                    FreelancerSkills freelancerSkill = new FreelancerSkills()
                    {
                        SkillId = skill.Id,
                        FreelancerId = freelancer.Id
                    };

                    newFreelancerSkills.Add(freelancerSkill);
                }

                freelancer.Skills = newFreelancerSkills;
            }

            _unitOfWork.Save();


            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 200,
                Message = "Freelancer updated successfully"
            };
        }

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