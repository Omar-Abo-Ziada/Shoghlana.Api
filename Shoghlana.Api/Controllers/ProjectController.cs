using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            return projectService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            return projectService.GetById(id);
        }

        [HttpGet("freelancer/{id:int}")]
        public ActionResult<GeneralResponse> GetByFreelancerId(int id)
        {
            return projectService.GetByfreelancerIdId(id);
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult<GeneralResponse>> AddAsync([FromForm] AddProjectDTO projectDTO)
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

            return await projectService.AddAsync(projectDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GeneralResponse>> UpdateAsync(int id, [FromForm] AddProjectDTO updateProjectDTO)
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
            return await projectService.UpdateAsync(id, updateProjectDTO);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<GeneralResponse> Delete(int id)
        {
            return projectService.Delete(id);
        }
    }
}