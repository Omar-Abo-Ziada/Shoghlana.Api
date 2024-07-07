using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Interfaces;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService skillService;

        public SkillController(ISkillService skillService)
        {
            this.skillService = skillService;
        }


        [HttpGet]
        public async Task <GeneralResponse> GetAllAsync()
        {
           return await skillService.GetAllAsync();
        }


        [HttpGet("{id:int}")] 
        public async Task<GeneralResponse> GetById(int id)
        {
            return await skillService.GetByIdAsync(id);
        }
    }
}
