using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Services.Implementaions;
using Shoghlana.Core.DTO;
namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatServices _chatServices;
        public ChatController(ChatServices chatService)
        {
            _chatServices = chatService;
        }

        [HttpPost("register-user")]
        //public IActionResult RegisterUser(chatDTO model)
        //{
        //    if(_chatServices.AddUsersToList(model.Name))
        //    {
        //        return NoContent();
        //    }
        //    return BadRequest("This name is taken please choose another name");
        //}
        //public IActionResult RegisterUser([FromBody] chatDTO model)
        //{
        //    if (model == null || string.IsNullOrWhiteSpace(model.Name))
        //    {
        //        return BadRequest("Invalid user data.");
        //    }

        //    if (_chatServices.AddUsersToList(model.Name))
        //    {
        //        return NoContent();
        //    }

        //    return BadRequest("This name is taken, please choose another name.");
        //}
        public IActionResult RegisterUser([FromBody] chatDTO model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Name))
            {
                return BadRequest("Invalid user data.");
            }

            if (_chatServices.AddUsersToList(model.Name))
            {
                return NoContent();
            }

            return BadRequest("This name is taken, please choose another name.");
        }
    }
}

  

