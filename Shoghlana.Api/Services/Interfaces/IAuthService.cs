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
    }
}