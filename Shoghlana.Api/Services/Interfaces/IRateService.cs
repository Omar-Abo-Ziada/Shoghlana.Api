using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Interfaces
{
    public interface IRateService : IGenericService<Rate>
    {
        public ActionResult<GeneralResponse> GetAll();

        public ActionResult<GeneralResponse> GetById(int id);

        public Task<ActionResult<GeneralResponse>> CreateRate(RateDTO rateDTO);

        public Task<ActionResult<GeneralResponse>> UpdateRate(int id, RateDTO rateDTO);

        public ActionResult<GeneralResponse> DeleteRate(int id);
    }
}
