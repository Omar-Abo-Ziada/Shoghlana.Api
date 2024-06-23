using Shoghlana.Api.Response;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Interfaces
{
    public interface ISkillService : IGenericService<Skill>
    {
        Task<GeneralResponse> GetAllAsync();
        Task<GeneralResponse> GetByIdAsync(int id);

    }
}
