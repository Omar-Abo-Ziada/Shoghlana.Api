using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Interfaces
{
    public interface IProjectService : IGenericService<Project>
    {
        public ActionResult<GeneralResponse> GetAll();

        public ActionResult<GeneralResponse> GetById(int id);

        public ActionResult<GeneralResponse> GetByfreelancerIdId(int id);

        public Task<ActionResult<GeneralResponse>> AddAsync([FromForm] AddProjectDTO projectDTO);

        public Task<ActionResult<GeneralResponse>> UpdateAsync(int id, [FromForm] AddProjectDTO updateProjectDTO);

        public ActionResult<GeneralResponse> Delete(int id);
    }
}