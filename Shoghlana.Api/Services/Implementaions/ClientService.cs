using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Implementaions
{
    public class ClientService : GenericService<Client> , IClientService
    {
        public ClientService(IUnitOfWork unitOfWork, IGenericRepository<Client> repository) : base(unitOfWork, repository)
        {
        }
    }
}
