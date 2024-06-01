using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Core.DTO;
using Shoghlana.Api.Response;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly List<string> allowedExtensions = new List<string>() { ".jpg", ".png" };
        private readonly long maxAllowedImageSize = 1_048_576; // 1 MB

        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Project> projects = _unitOfWork.project.FindAll(includes: new string[] { "skills", "Images" }).ToList();
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
                Skills = project.skills?.Select(skill => new SkillDTO
                {
                    Title = skill.Title,
                    Description = skill.Description
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



        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            Project project = _unitOfWork.project.Find(includes: new string[] { "skills", "Images" }, criteria: p => p.Id == id);

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
                Skills = project.skills?.Select(skill => new SkillDTO
                {
                    Title = skill.Title,
                    Description = skill.Description
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




        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> AddAsync([FromForm] ProjectDTO projectDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Status = 400,
                    Data = ModelState,
                    Message = "Invalid Model State!"
                };
            }

            if (projectDTO.Poster == null)
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
                skills = projectDTO.Skills?.Select(skillDTO => new Skill
                {
                    Title = skillDTO.Title,
                    Description = skillDTO.Description
                }).ToList(),
                Images = images
            };

            await _unitOfWork.project.AddAsync(project);
            _unitOfWork.Save();

            return new GeneralResponse
            {
                IsSuccess = true,
                Status = 201,
                Data = projectDTO,
                Message = "Added Successfully"
            };
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GeneralResponse>> UpdateAsync(int id, [FromForm] ProjectDTO updateProjectDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Status = 400,
                    Data = ModelState,
                    Message = "Invalid Model State!"
                };
            }

            Project project = _unitOfWork.project.GetById(id);

            if (project == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "There is no Project found with this ID!"
                };
            }

            if (updateProjectDTO.Poster != null)
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
            if (updateProjectDTO.Images != null)
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
                }
                project.Images = images;
            }

            project.Title = updateProjectDTO.Title;
            project.Description = updateProjectDTO.Description;
            project.Link = updateProjectDTO.Link;
            project.TimePublished = updateProjectDTO.TimePublished;
            project.FreelancerId = updateProjectDTO.FreelancerId;

            project.skills ??= new List<Skill>();
            project.skills.Clear();
            if (updateProjectDTO.Skills != null)
            {
                project.skills.AddRange(updateProjectDTO.Skills.Select(skillDTO => new Skill
                {
                    Title = skillDTO.Title,
                    Description = skillDTO.Description
                }));
            }

            _unitOfWork.Save();

            ProjectDTO updatedProjectDTO = new ProjectDTO
            {
                Title = project.Title,
                Description = project.Description,
                Link = project.Link,
                Poster = project.Poster != null ? new FormFile(new MemoryStream(project.Poster), 0, project.Poster.Length, null, Path.GetFileName(project.Poster.ToString())) : null,
                Images = project.Images?.Select(image => new ImageDTO { Image = new FormFile(new MemoryStream(image.Image), 0, image.Image.Length, null, Path.GetFileName(image.Image.ToString())) }).ToList(),
                Skills = project.skills?.Select(skill => new SkillDTO
                {
                    Title = skill.Title,
                    Description = skill.Description
                }).ToList(),
                TimePublished = project.TimePublished,
                FreelancerId = project.FreelancerId
            };

            return new GeneralResponse
            {
                IsSuccess = true,
                Status = 200,
                Data = updatedProjectDTO,
                Message = "Project updated successfully"
            };
        }


        [HttpDelete("{id:int}")]
        public ActionResult<GeneralResponse> Delete(int id)
        {
            Project project = _unitOfWork.project.GetById(id);

            if (project == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "There is no Project found with this ID!"
                };
            }

            _unitOfWork.project.Delete(project);
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
