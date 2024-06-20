using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementaions;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.Models;
using System.Net;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly IAuthService _authservice;
        private readonly UserManager<ApplicationUser> _userManager;


        public MailController(IMailService mailService, UserManager<ApplicationUser> userManager, IAuthService authservice)
        {
            _mailService = mailService;
            _userManager = userManager;
            _authservice = authservice;
        }

        [HttpPost("SendConfirmationEmail")]
        public async Task<GeneralResponse> SendConfirmationEmail(string toemail)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(toemail);
            if (user == null || string.IsNullOrEmpty(user.Email))
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Status = 400,
                    Data = ModelState,
                    Message = "Invalid Mail Address or there is no user"
                };
            }
            else
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string confirmationLink = Url.Action("ConfirmEmail", "Auth", new { userEmail = user.Email, token }, Request.Scheme);

                string subject = "Email Confirmation";
                string body = $"<h1>Welcome to Shoghlana!</h1>" +
                              $"<p>Please confirm your email by clicking on the link below:</p>" +
                              $"<a href='{confirmationLink}'>Confirm Email</a>";

                await _mailService.SendEmailAsync(user.Email, subject, body);

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Data = ModelState,
                    Status = 200,
                    Message = " mail sent  "

                };
            }
        }

    }
}

