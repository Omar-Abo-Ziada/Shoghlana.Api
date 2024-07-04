using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {
        private readonly IFreelancerService freelancerService;

        public FreelancerController(IFreelancerService freelancerService)
        {
            this.freelancerService = freelancerService;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            return freelancerService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            return freelancerService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> AddAsync([FromForm] AddFreelancerDTO addedFreelancerDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Data = ModelState,
                    Message = "Invalid Model State !"
                };
            }

            return await freelancerService.AddAsync(addedFreelancerDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GeneralResponse>> UpdateAsync(int id, [FromForm] AddFreelancerDTO addedFreelancerDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Data = ModelState,
                    Message = "Invalid Model State !"
                };
            }

            return await freelancerService.UpdateAsync(id, addedFreelancerDTO);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<GeneralResponse> Delete(int id)
        {
            return freelancerService.Delete(id);
        }

        [HttpGet("Notifications/{freelancerId:int}")]
        public ActionResult<GeneralResponse> GetNotificationsByFreelancerId(int freelancerId)
        {
            return freelancerService.GetNotificationsByFreelancerId(freelancerId);
        }
    }
}