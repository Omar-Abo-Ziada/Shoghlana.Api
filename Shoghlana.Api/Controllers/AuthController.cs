using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.Models;
using System.Net;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMailService _mailService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthController(IAuthService authService, UserManager<ApplicationUser> userManager, IMailService mailService)
        {
            _authService = authService;
            _userManager = userManager;
            _mailService = mailService;
        }

        [HttpPost("Register")]
        public async Task<GeneralResponse> RegisterAsync([FromBody] RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {

                var result = await _authService.RegisterAsync(registerModel);
                //ApplicationUser user = await _userManager.FindByEmailAsync(registerModel.Email);
                //if (user == null || string.IsNullOrEmpty(user.Email))
                //{
                //    return new GeneralResponse
                //    {
                //        IsSuccess = false,
                //        Status = 400,
                //        Data = ModelState,
                //        Message = "Invalid Mail Address or there is no user"
                //    };
                //}
                //else
                //{
                //    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //    string confirmationLink = Url.Action("ConfirmEmail", "Auth", new { userEmail = user.Email, token }, Request.Scheme);

                //    string subject = "Email Confirmation";
                //    string body = $"<h1>Welcome to Shoghlana!</h1>" +
                //                  $"<p>Please confirm your email by clicking on the link below:</p>" +
                //                  $"<a href='{confirmationLink}'>Confirm Email</a>";

                //    await _mailService.SendEmailAsync(user.Email, subject, body);
                //}
                if (result.IsAuthenticated )
                {
                    SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

                    return new GeneralResponse
                    {
                        Data = result,
                        IsSuccess = true,
                        Message = "Authenticated",
                        //Token = result.Token
                    };
                }
                else
                {
                    return new GeneralResponse
                    {
                        Data = registerModel,
                        IsSuccess = false,
                        Status = 400,
                        Message = result.Message,
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

        [HttpGet("ConfirmEmail")]

        public async Task<GeneralResponse> ConfirmEmail(string userEmail, string token)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Status = 400,
                    Data = null,
                    Message = "Invalid mail address"
                };
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                user.EmailConfirmed = true;
                var jwtSecurityToken = await _authService.CreateJwtToken(user);
                
                await _userManager.UpdateAsync(user);
                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = user.Email,
                    Status = 200,
                    Message = "Email confirmed successfully",
                    Token = jwtSecurityToken.ToString()
                    };
            }
            else
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Data = result.Errors,
                    Message = "Error confirming email"
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
                    if (!string.IsNullOrEmpty(result.RefreshToken))
                        SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

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

        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var result = await _authService.RefreshTokenAsync(refreshToken);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }

        [HttpPost("revokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeToken model)
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is required!");

            var result = await _authService.RevokeTokenAsync(token);

            if (!result)
                return BadRequest("Token is invalid!");

            return Ok();
        }

        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime(),
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}