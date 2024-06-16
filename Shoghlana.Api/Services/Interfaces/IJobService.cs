using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementaions;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repositories;

namespace Shoghlana.Api.Services.Interfaces
{
    public interface IJobService : IGenericService<Job>
    {
        public ActionResult<GeneralResponse> GetAll();

        public ActionResult<GeneralResponse> Get(int id);

        public ActionResult<GeneralResponse> GetByFreelancerId([FromQuery] int id);

        public ActionResult<GeneralResponse> GetJobsByCategoryId(int id);

        public ActionResult<GeneralResponse> GetJobsByCategoryIds([FromQuery] List<int> ids);

        public ActionResult<GeneralResponse> GetByClientId([FromQuery] int id);

        public ActionResult<GeneralResponse> Add(JobDTO jobDto);

        public ActionResult<GeneralResponse> update(JobDTO jobDto);

        public ActionResult<GeneralResponse> delete(int id);
    }
}
