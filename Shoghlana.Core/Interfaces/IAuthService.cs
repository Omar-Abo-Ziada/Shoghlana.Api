using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model );
        Task<AuthModel> GetTokenAsync(TokenRequestModel model );
        Task<string> AddRoleAsync(AddRoleModel model);

    }
}
