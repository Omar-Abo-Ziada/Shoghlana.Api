using Shoghlana.Core.Models;
using System.IdentityModel.Tokens.Jwt;

﻿using Shoghlana.Api.Response;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Interfaces
{
    public interface IAuthService 
    {
        Task<AuthModel> RegisterAsync(RegisterModel model );

        Task<AuthModel> GetTokenAsync(TokenRequestModel model );

        Task<string> AddRoleAsync(AddRoleModel model);

        Task<AuthModel> RefreshTokenAsync(string token);


        Task<bool> RevokeTokenAsync(string token);
        Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user);

        //reset password 
        //Task<AuthModel> ForgotPasswordAsync(string email);
        //Task<AuthModel> ResetPasswordAsync(ResetPasswordRequest request);

        // google authentication
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<GeneralResponse> GoogleAuthentication(GoogleSignupDto googleSignupDto);
        Task<GeneralResponse> IsGmailTokenValidAsync(string GmailToken);

    }
}