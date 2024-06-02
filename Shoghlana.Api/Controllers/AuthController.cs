using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<GeneralResponse> RegisterAsync([FromBody] RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterAsync(registerModel);
                if (result.IsAuthenticated)
                {
                    return new GeneralResponse
                    {
                        Data = result,
                        IsSuccess = true,
                        Message = "Authenticated",
                        Token = result.Token
                    };
                }
                else
                {
                    return new GeneralResponse
                    {
                        Data = registerModel,
                        IsSuccess = false,
                        Message = result.Message
                    };
                }
            }
            else
            {
                return new GeneralResponse
                {
                    Data = ModelState,
                    IsSuccess = false,
                    Message = ModelState.ToString()

                };
            }
        }


        [HttpPost("Token")]
        public async Task<GeneralResponse> GetTokenAsync([FromBody] TokenRequestModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.GetTokenAsync(registerModel);
                if (result.IsAuthenticated)
                {
                    return new GeneralResponse
                    {
                        Data = result,
                        IsSuccess = true,
                        Message = "Authenticated",
                        Token = result.Token
                    };
                }
                else
                {
                    return new GeneralResponse
                    {
                        Data = registerModel,
                        IsSuccess = false,
                        Message = result.Message
                    };
                }
            }
            else
            {
                return new GeneralResponse
                {
                    Data = ModelState,
                    IsSuccess = false,
                    Message = ModelState.ToString()

                };
            }
        }



        [HttpPost("addrole")]
        public async Task<GeneralResponse> AddRoleAsync([FromBody] AddRoleModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await _authService.AddRoleAsync(model);
                if (!string.IsNullOrEmpty(result))
                {
                    return new GeneralResponse
                    {
                        Data = model,
                        IsSuccess = false,
                        Message = result
                    };
                }
                else
                {
                    return new GeneralResponse
                    {
                        Data = model,
                        IsSuccess = true,
                        Message = result
                    };
                }
            }
            else
            {
                return new GeneralResponse
                {
                    Data = ModelState,
                    IsSuccess = false,
                    Message = ModelState.ToString()

                };
            }

        }

    }
}
