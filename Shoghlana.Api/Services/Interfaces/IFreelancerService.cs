using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementaions;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Interfaces
{
    public interface IFreelancerService : IGenericService<Freelancer>
    {
        public ActionResult<GeneralResponse> GetAll();

        public ActionResult<GeneralResponse> GetById(int id);

        public Task<ActionResult<GeneralResponse>> AddAsync(AddFreelancerDTO addedFreelancerDTO);
               
        public Task<ActionResult<GeneralResponse>> UpdateAsync(int id, [FromForm] AddFreelancerDTO addedFreelancerDTO);

        public ActionResult<GeneralResponse> Delete(int id);
    }
}