using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Shoghlana.Api.Hubs;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementaions;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRateService rateService;

        public RateController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            return rateService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            return rateService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> CreateRate(RateDTO rateDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "Invalid rate data"
                };
            }

            return await rateService.CreateRate(rateDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GeneralResponse>> UpdateRate(int id, RateDTO rateDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "Invalid rate data"
                };
            }

            return await rateService.UpdateRate(id, rateDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult<GeneralResponse> DeleteRate(int id)
        {
            return rateService.DeleteRate(id);
        }
    }
}