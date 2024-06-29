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
                string confirmationLink = Url.Action("ConfirmEmail", "Mail", new { userEmail = user.Email, token }, Request.Scheme);

                string subject = "Email Confirmation";
                string body = $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n  <title>Email Confirmation</title>\r\n  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n  <style>\r\n    body {{\r\n      background: #f9f9f9;\r\n      margin: 0;\r\n      padding: 0;\r\n    }}\r\n    .container {{\r\n      max-width: 640px;\r\n      margin: 0 auto;\r\n      background: #ffffff;\r\n      box-shadow: 0px 1px 5px rgba(0, 0, 0, 0.1);\r\n      border-radius: 4px;\r\n      overflow: hidden;\r\n    }}\r\n  </style>\r\n</head>\r\n<body>\r\n  <div class=\"container\">\r\n    <div style=\"background-color: #7289da; padding: 57px; text-align: center;\">\r\n      <div style=\"cursor: auto; color: white; font-family: Arial, sans-serif; font-size: 36px; font-weight: 600;\">\r\n        Welcome to Shoghlana !!\r\n      </div>\r\n    </div>\r\n    \r\n    <div style=\"padding: 40px 70px;\">\r\n      <div style=\"color: #737f8d; font-family: Arial, sans-serif; font-size: 16px; line-height: 24px;\">\r\n        <h2 style=\"font-weight: 500; font-size: 20px; color: #4f545c;\">Hey {user.UserName},</h2>\r\n        <p>\r\n          Welcome aboard Shoghlana! 🚀 Thanks for signing up! We're thrilled to have you join our community.\r\n        </p>\r\n        <p>\r\n          To get started, we just need to confirm your email address to ensure everything runs smoothly.\r\n        </p>\r\n        <p>\r\n          Click the button below to verify your email and unlock all the amazing features Shoghlana has to offer:\r\n        </p>\r\n      </div>\r\n      <div style=\"text-align: center; padding: 20px;\">\r\n        <a href=\"{confirmationLink}\" style=\"display: inline-block; background-color: #7289da; color: white; text-decoration: none; padding: 15px 30px; border-radius: 3px;\">Verify Email</a>\r\n      </div>\r\n      <div style=\"color: #737f8d; font-family: Arial, sans-serif; font-size: 16px; line-height: 24px;\">\r\n        <p>If you have any questions or need assistance, feel free to reach out to our support team.</p>\r\n       </div>\r\n    </div>\r\n  </div>\r\n</body>\r\n</html>\r\n";

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

        [HttpGet("ConfirmEmail")]

        public async Task< ContentResult> ConfirmEmail(string userEmail, string token)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                var htmlfailed = "<div class=\"container\">\r\n        <p class=\"message\">somthing wrong with your email ! </p>   </div>";
                return new ContentResult
                {
                    Content = htmlfailed,
                    ContentType= "text/html"
                };
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                user.EmailConfirmed = true;
                var jwtSecurityToken = await _authservice.CreateJwtToken(user);

                await _userManager.UpdateAsync(user);
                var htmlsuccess = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Email Confirmation</title>\r\n    <style>\r\n        body {\r\n            font-family: Arial, sans-serif;\r\n            display: flex;\r\n            justify-content: center;\r\n            align-items: center;\r\n            height: 100vh;\r\n            margin: 0;\r\n            background-color: #f4f4f9;\r\n        }\r\n        .container {\r\n            text-align: center;\r\n            background: #fff;\r\n            padding: 40px;\r\n            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);\r\n            border-radius: 10px;\r\n            max-width: 500px;\r\n            width: 90%;\r\n        }\r\n        .logo {\r\n            max-width: 100%;\r\n            height: auto;\r\n            margin-bottom: 20px;\r\n        }\r\n        .message {\r\n            font-size: 1.5em;\r\n            color: #333;\r\n            margin-bottom: 20px;\r\n            line-height: 1.4;\r\n        }\r\n        .button {\r\n            background-color: #007BFF;\r\n            color: white;\r\n            border: none;\r\n            padding: 15px 30px;\r\n            font-size: 1.2em;\r\n            border-radius: 5px;\r\n            cursor: pointer;\r\n            text-decoration: none;\r\n            transition: background-color 0.3s, transform 0.3s;\r\n        }\r\n        .button:hover {\r\n            background-color: #0056b3;\r\n            transform: translateY(-2px);\r\n        }\r\n        .button:active {\r\n            background-color: #004494;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <img src=\"~wwwroot\\Images\\logo.jpeg\" alt=\"Shoghlana Logo\" class=\"logo\">\r\n        <p class=\"message\">Your email has been confirmed successfully! <br> <br> You can now start your journey with our site, Shoghlana!!!</p>\r\n   <br>     <a href=\"http://localhost:4200/signin\" class=\"button\">Start Your Journey</a>\r\n    </div>\r\n</body>\r\n</html>\r\n";
                return new ContentResult
                {
                    Content = htmlsuccess,
                    ContentType = "text/html"
                };
            }

            else
            {
                var htmlfailed = "<div class=\"container\">\r\n        <p class=\"message\">somthing wrong we can't confirm your email try again our contact us ! </p>   </div>";
                return new ContentResult
                {
                    Content = htmlfailed,
                    ContentType = "text/html"
                };
            }
        }

    }
}

