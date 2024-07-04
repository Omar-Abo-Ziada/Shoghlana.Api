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
    public class ProjectService : GenericService<Project>, IProjectService
    {
        // TODO I fixed the GetbyfreelancerID skills dto and getprojectDTO and tested it ,, Don't forget to check the others (get all , get by ID)
        private readonly IMapper mapper;

        private readonly List<string> allowedExtensions = new List<string>() { ".jpg", ".png" , "jpeg" };

        private readonly long maxAllowedImageSize = 1_048_576; // 1 MB

        public ProjectService(IUnitOfWork unitOfWork, IGenericRepository<Project> repository, IMapper mapper) : base(unitOfWork, repository)
        {
            this.mapper = mapper;
        }

        public ActionResult<GeneralResponse> GetByfreelancerIdId(int id)
        {
            List<Project>? projects = _unitOfWork.projectRepository
                    .FindAll(includes: ["Images", "Skills"], criteria: p => p.FreelancerId == id).ToList();

            if (projects is null || projects.Count == 0)
            {
                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = null,
                    Message = $"No Projects found for this freelancer (ID = {id})",
                    Status = 400,
                };
            }

            List<GetProjectDTO> projectDTOs = new List<GetProjectDTO>();

            foreach (var project in projects)
            {
                GetProjectDTO projectDTO = mapper.Map<GetProjectDTO>(project);

                List<int>? skillsIDs = project?.Skills?.Select(s => s.SkillId).ToList();

                if (skillsIDs is not null && skillsIDs.Any())
                {
                    List<Skill> skills = _unitOfWork.skillRepository.FindAll(criteria: s => skillsIDs.Contains(s.Id)).ToList();

                    List<SkillDTO> skillsDTOs = new List<SkillDTO>();

                    foreach (var skill in skills)
                    {
                        SkillDTO skillDTO = mapper.Map<SkillDTO>(skill);

                        skillsDTOs.Add(skillDTO);
                    }

                    projectDTO.Skills = skillsDTOs;
                }

                foreach (var image in project.Images)
                {
                    GetImageDTO imageDTO = mapper.Map<GetImageDTO>(image);

                    projectDTO.Images.Add(imageDTO);
                }

                projectDTO.Poster = project.Poster;

                projectDTOs.Add(projectDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = projectDTOs,
                Status = 200,
                Message = $"The projects done by the freelancer with ID = {id}"
            };
        }

        public ActionResult<GeneralResponse> GetAll()
        {
            List<Project> projects = _unitOfWork.projectRepository.FindAll(includes: ["Skills", "Images"]).ToList();

            List<GetProjectDTO> projectDTOs = projects.Select(project => new GetProjectDTO
            {
                Title = project.Title,
                Description = project.Description,
                Link = project.Link,
                Poster = project.Poster,
                Images = project.Images?.Select(image => new GetImageDTO
                {
                    Image = image.Image
                }).ToList(),

                Skills = project.Skills?.Select(skill => new SkillDTO
                {
                    // TODO : Omar => Check for null first
                    Title = _unitOfWork.skillRepository.GetById(skill.SkillId).Title,

                    Description = _unitOfWork.skillRepository.GetById(skill.SkillId).Description
                }).ToList(),

                TimePublished = project.TimePublished,
                FreelancerId = project.FreelancerId
            }).ToList();

            return new GeneralResponse
            {
                IsSuccess = true,
                Status = 200,
                Data = projectDTOs
            };
        }

        public ActionResult<GeneralResponse> GetById(int id)
        {
            Project? project = _unitOfWork.projectRepository.Find(includes: ["Skills", "Images"], criteria: p => p.Id == id);

            if (project == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Status = 400, // bad request
                    Message = "There is no Project found with this ID!"
                };
            }

            GetProjectDTO projectDto = new GetProjectDTO
            {
                Title = project.Title,
                Description = project.Description,
                Link = project.Link,
                Poster = project.Poster, // Assuming Poster is already byte[]
                Images = project.Images?.Select(image => new GetImageDTO { Image = image.Image }).ToList(),

                Skills = project.Skills?.Select(skill => new SkillDTO
                {
                    // TODO : Omar => Check for null first
                    Title = _unitOfWork.skillRepository.GetById(skill.SkillId).Title,
                    Description = _unitOfWork.skillRepository.GetById(skill.SkillId).Description
                }).ToList(),

                TimePublished = project.TimePublished,
                FreelancerId = project.FreelancerId
            };

            return new GeneralResponse
            {
                IsSuccess = true,
                Status = 200,
                Data = projectDto
            };
        }

        public async Task<ActionResult<GeneralResponse>> AddAsync([FromForm] AddProjectDTO projectDTO)
        {
            if (projectDTO.Poster is null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "Poster is required"
                };
            }

            if (!allowedExtensions.Contains(Path.GetExtension(projectDTO.Poster.FileName).ToLower()))
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "The allowed image extensions for poster are: jpg, png"
                };
            }

            if (projectDTO.Poster.Length > maxAllowedImageSize)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "The maximum allowed poster size is 1 MB"
                };
            }

            using var posterDataStream = new MemoryStream();

            await projectDTO.Poster.CopyToAsync(posterDataStream);

            List<ProjectImages> images = new List<ProjectImages>();

            if (projectDTO.Images != null)
            {
                foreach (var imageDTO in projectDTO.Images)
                {
                    if (!allowedExtensions.Contains(Path.GetExtension(imageDTO.Image.FileName).ToLower()))
                    {
                        return new GeneralResponse
                        {
                            IsSuccess = false,
                            Status = 400,
                            Message = "The allowed image extensions are: jpg, png"
                        };
                    }

                    if (imageDTO.Image.Length > maxAllowedImageSize)
                    {
                        return new GeneralResponse
                        {
                            IsSuccess = false,
                            Status = 400,
                            Message = "The maximum allowed image size is 1 MB"
                        };
                    }

                    using var imageDataStream = new MemoryStream();
                    await imageDTO.Image.CopyToAsync(imageDataStream);
                    images.Add(new ProjectImages { Image = imageDataStream.ToArray() });
                }
            }

            Project project = new Project
            {
                Title = projectDTO.Title,
                Description = projectDTO.Description,
                Link = projectDTO.Link,
                Poster = posterDataStream.ToArray(),
                TimePublished = projectDTO.TimePublished,
                FreelancerId = projectDTO.FreelancerId,
                Images = images
            };

            await _unitOfWork.projectRepository.AddAsync(project);

            await _unitOfWork.SaveAsync(); // so that the project takes ID from EF

            List<Skill> skills = (await _unitOfWork.skillRepository.FindAllAsync(criteria: s => projectDTO.SkillIDs.Contains(s.Id))).ToList();

            List<ProjectSkills> projectSkills = new List<ProjectSkills>(skills.Count);

            foreach (var skill in skills)
            {
                ProjectSkills projectSkill = new ProjectSkills()
                {
                    SkillId = skill.Id,
                    ProjectId = project.Id
                };

                projectSkills.Add(projectSkill);
            }

            project.Skills = projectSkills;

            await _unitOfWork.SaveAsync();

            //project.Skills = projectDTO.Skills?.Select(skillDTO => new ProjectSkills   // skills are added after project id is generated
            //{
            //    //SkillId = skillDTO.Id,
            //    ProjectId = project.Id
            //}).ToList();

            //_unitOfWork.projectRepository.Update(project);

            return new GeneralResponse
            {
                IsSuccess = true,
                Status = 201,
                Data = null,
                Message = "Added Successfully"
            };
        }

        public async Task<ActionResult<GeneralResponse>> UpdateAsync(int id, [FromForm] AddProjectDTO updateProjectDTO)
        {
            Project? project = await _unitOfWork.projectRepository.GetByIdAsync(updateProjectDTO.ProjectId);

            if (project is null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "There is no Project found with this ID!"
                };
            }

            if (updateProjectDTO.Poster is not null)
            {
                if (!allowedExtensions.Contains(Path.GetExtension(updateProjectDTO.Poster.FileName).ToLower()))
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Status = 400,
                        Message = "The allowed image extensions for poster are: jpg, png"
                    };
                }

                if (updateProjectDTO.Poster.Length > maxAllowedImageSize)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Status = 400,
                        Message = "The maximum allowed poster size is 1 MB"
                    };
                }

                using var posterDataStream = new MemoryStream();
                await updateProjectDTO.Poster.CopyToAsync(posterDataStream);
                project.Poster = posterDataStream.ToArray();
            }

            List<ProjectImages> images = new List<ProjectImages>();

            if (updateProjectDTO.Images is not null && updateProjectDTO.Images.Any())
            {
                foreach (var imageDTO in updateProjectDTO.Images)
                {
                    if (!allowedExtensions.Contains(Path.GetExtension(imageDTO.Image.FileName).ToLower()))
                    {
                        return new GeneralResponse
                        {
                            IsSuccess = false,
                            Status = 400,
                            Message = "The allowed image extensions are: jpg, png"
                        };
                    }

                    if (imageDTO.Image.Length > maxAllowedImageSize)
                    {
                        return new GeneralResponse
                        {
                            IsSuccess = false,
                            Status = 400,
                            Message = "The maximum allowed image size is 1 MB"
                        };
                    }

                    using var imageDataStream = new MemoryStream();
                    await imageDTO.Image.CopyToAsync(imageDataStream);
                    images.Add(new ProjectImages { Image = imageDataStream.ToArray() });

                    project.Images = images;
                }
            }

            project.Title = updateProjectDTO.Title;
            project.Description = updateProjectDTO.Description;
            project.Link = updateProjectDTO.Link;
            project.TimePublished = updateProjectDTO.TimePublished;
            project.FreelancerId = updateProjectDTO.FreelancerId;

            if(updateProjectDTO.SkillIDs is not null && updateProjectDTO.SkillIDs.Any())
            {
                // deleing the prev list first before adding the new one

                IEnumerable<ProjectSkills> oldprojectSkills = await _unitOfWork.projectSkillsRepository.FindAllAsync(criteria: ps => ps.ProjectId == updateProjectDTO.ProjectId);

                _unitOfWork.projectSkillsRepository.DeleteRange(oldprojectSkills);

                List<Skill> skills = (await _unitOfWork.skillRepository.FindAllAsync(criteria: s => updateProjectDTO.SkillIDs.Contains(s.Id))).ToList();

                List<ProjectSkills> newProjectSkills = new List<ProjectSkills>(skills.Count);

                foreach (var skill in skills)
                {
                    ProjectSkills projectSkill = new ProjectSkills()
                    {
                        SkillId = skill.Id,
                        ProjectId = project.Id
                    };

                    newProjectSkills.Add(projectSkill);
                }

                project.Skills = newProjectSkills;
            }
         
            _unitOfWork.Save();

            //project.Skills ??= new List<ProjectSkills>();
            //project?.Skills?.Clear();

            //if (updateProjectDTO.Skills != null)
            //{
            //    project?.Skills?.AddRange(updateProjectDTO.Skills.Select(skillDTO => new ProjectSkills
            //    {
            //        ProjectId = project.Id,
            //        SkillId = skillDTO.Id
            //    }));
            //}

            //AddProjectDTO updatedProjectDTO = new AddProjectDTO
            //{
            //    Title = project.Title,
            //    Description = project.Description,
            //    Link = project.Link,
            //    Poster = project.Poster != null ? new FormFile(new MemoryStream(project.Poster), 0, project.Poster.Length, null, Path.GetFileName(project.Poster.ToString())) : null,
            //    Images = project.Images?.Select(image => new ImageDTO { Image = new FormFile(new MemoryStream(image.Image), 0, image.Image.Length, null, Path.GetFileName(image.Image.ToString())) }).ToList(),
            //    Skills = project.Skills?.Select(skill =>

            //    new SkillDTO
            //    {
            //        // TODO : Omar => Check for null first
            //        Title = _unitOfWork.skillRepository.GetById(skill.SkillId).Title,
            //        Description = _unitOfWork.skillRepository.GetById(skill.SkillId).Description,
            //    }).ToList(),
            //    TimePublished = project.TimePublished,
            //    FreelancerId = project.FreelancerId
            //};

            return new GeneralResponse
            {
                IsSuccess = true,
                Status = 200,
                //Data = updatedProjectDTO,
                Message = "Project updated successfully"
            };
        }

        public ActionResult<GeneralResponse> Delete(int id)
        {
            Project project = _unitOfWork.projectRepository.GetById(id);

            if (project == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "There is no Project found with this ID!"
                };
            }

            // deleing the prev list first before adding the new one

            IEnumerable<ProjectSkills> oldprojectSkills =  _unitOfWork.projectSkillsRepository.FindAll(criteria: ps => ps.ProjectId == id);

            _unitOfWork.projectSkillsRepository.DeleteRange(oldprojectSkills);

            _unitOfWork.projectRepository.Delete(project);

            _unitOfWork.Save();

            return new GeneralResponse
            {
                IsSuccess = true,
                Status = 200,
                Message = $"The Project with ID ({project.Id}) is deleted successfully!"
            };
        }

    }
}