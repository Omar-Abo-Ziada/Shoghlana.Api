using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shoghlana.Api.Hubs;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Helpers;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace Shoghlana.Api.Services.Implementaions
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Jwt _jwt;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFreelancerService _freelancerService;

        public AuthService
        (UserManager<ApplicationUser> userManager, IOptions<Jwt> jwt,
         RoleManager<IdentityRole> roleManager, IHubContext<NotificationHub> hubContext, IUnitOfWork unitOfWork,
         IFreelancerService freelancerService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _hubContext = hubContext;
            _unitOfWork = unitOfWork;
            _freelancerService = freelancerService;
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model) 
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                return new AuthModel { Message = "Email is already registered!" };
            }

            if (await _userManager.FindByNameAsync(model.Username) is not null)
            {
                return new AuthModel { Message = "Username is already registered!" };
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,

                Email = model.Email,

                //PhoneNumber = model.PhoneNumber,

                //NormalizedEmail = model.Email ,

                //PasswordHash = model.Password,

                // TODO the mail and password ? 
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return new AuthModel { Message = errors };
            }

            // Send a welcome notification to the user
            await SendWelcomeNotificationAsync(user);

            var jwtSecurityToken = await CreateJwtToken(user);

            // Determine the user's roles
            var roles = await _userManager.GetRolesAsync(user);
            var refreshToken = GenerateRefreshToken();
            user.RefreshTokens?.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            return new AuthModel
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = roles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshToken.ExpiresOn
            };
        }

        private async Task SendWelcomeNotificationAsync(ApplicationUser user)
        {
            var notification = new NotificationDTO
            {
                Title = "Welcome to Shoglana!",
                description = $"Welcome, {user.UserName}! Thank you for joining us.",
                sentTime = DateTime.Now,
                // You can include the user's image in the notification if available

            };

            await _hubContext.Clients.User(user.Id).SendAsync("ReceiveNotification", notification);
        }

        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            if (await _userManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Sonething went wrong";
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                authModel.RefreshToken = activeRefreshToken.Token;
                authModel.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authModel.RefreshToken = refreshToken.Token;
                authModel.RefreshTokenExpiration = refreshToken.ExpiresOn;
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }

            return authModel;
        }

        public async Task<AuthModel> RefreshTokenAsync(string token)
        {
            var authModel = new AuthModel();

            var user = await _userManager
                .Users
                .SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
            {
                authModel.Message = "Invalid token";
                return authModel;
            }

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
            {
                authModel.Message = "Inactive token";
                return authModel;
            }

            refreshToken.RevokedOn = DateTime.UtcNow;

            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);

            var jwtToken = await CreateJwtToken(user);
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            var roles = await _userManager.GetRolesAsync(user);
            authModel.Roles = roles.ToList();
            authModel.RefreshToken = newRefreshToken.Token;
            authModel.RefreshTokenExpiration = newRefreshToken.ExpiresOn;

            return authModel;
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
                return false;

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
                return false;

            refreshToken.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);

            return true;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow
            };
        }



        // google authentication

        public async Task<ApplicationUser> GetByIdAsync(string id) 
        {
            return await _unitOfWork.ApplicationUserRepository.GetByIdAsync(id);
        }


        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            return await _unitOfWork.ApplicationUserRepository.GetByEmailAsync(email);
        }


        public async Task<GeneralResponse> RegisterAsync(GoogleSignupDto googleSignupDto)
        {
            ApplicationUser? User = await _unitOfWork.ApplicationUserRepository.GetByEmailAsync(googleSignupDto.email);
            if (User == null)
            {
                //// apply login logic here
                //return await Task.FromResult(new GeneralResponse()
                //{
                //    IsSuccess = false,
                //    Data = null,
                //    Message = "This email has already been registered before"
                //});


                Freelancer freelancer = new Freelancer()  // consider it is a freelancer for testing
                {
                    Name = googleSignupDto.firstName
                    // convert img from string to bytes and save it in freelancer
                };

                try
                {
                    _freelancerService.Add(freelancer);   // add + save inside the same method
                }
                catch (Exception ex)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = ex.Message
                    };
                }

                User = new ApplicationUser()
                {
                    UserName = googleSignupDto.firstName,     // should add guid as suffix as gmail allow username duplication but identity user doesnot
                    Email = googleSignupDto.email,
                    FreeLancerId = freelancer.Id,
                    EmailConfirmed = true                      // as he registered using gmail
                };

                try
                {
                    await _unitOfWork.ApplicationUserRepository.InsertAsync(User);
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(new GeneralResponse()
                    {
                        IsSuccess = false,
                        Data = ex.Message,
                        Message = "Error on account creation"
                    });
                }

                try
                {
                    await SendWelcomeNotificationAsync(User);
                }
                catch (Exception ex)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Data = ex.Message,
                        Message = "Error on sending welcome notification"
                    };
                }

            }

            // logic for login
            AuthModel authModel = new AuthModel();

            var jwtSecurityToken = await CreateJwtToken(User);
            var rolesList = await _userManager.GetRolesAsync(User);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = User.Email;
            authModel.Username = User.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            // refresh token 

            //if (User.RefreshTokens.Any(t => t.IsActive))
            //{
            //    var activeRefreshToken = User.RefreshTokens.FirstOrDefault(t => t.IsActive);
            //    authModel.RefreshToken = activeRefreshToken.Token;
            //    authModel.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            //}
            //else
            //{
            //    var refreshToken = GenerateRefreshToken();
            //    authModel.RefreshToken = refreshToken.Token;
            //    authModel.RefreshTokenExpiration = refreshToken.ExpiresOn;
            //    User.RefreshTokens.Add(refreshToken);
            //    await _userManager.UpdateAsync(User);
            //}

            return authModel;


        }



        public async Task<GeneralResponse> IsGmailTokenValid(string GmailToken)
        {
            ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new string[] { _googleAuthConfig.ClientId }
            };

            Payload payload = await GoogleJsonWebSignature.ValidateAsync(GmailToken, settings); // validate that aud of token matches clienId of my project on google cloud api
            if (payload == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "Invalid gmail token"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = payload,
                Message = "Valid gmail token"
            };
        }


    }
}