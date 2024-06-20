using Shoghlana.Core.Models;
using System.IdentityModel.Tokens.Jwt;

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
    }
}