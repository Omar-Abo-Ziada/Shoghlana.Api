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

        public Task<ActionResult<GeneralResponse>> AddAsync([FromForm] ProjectDTO projectDTO);

        public Task<ActionResult<GeneralResponse>> UpdateAsync(int id, [FromForm] ProjectDTO updateProjectDTO);

        public ActionResult<GeneralResponse> Delete(int id);
    }
}