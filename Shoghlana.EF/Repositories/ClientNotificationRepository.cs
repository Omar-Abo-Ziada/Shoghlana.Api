using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repository;

namespace Shoghlana.EF.Repositories
{
    public class ClientNotificationRepository : GenericRepository<ClientNotification>, IClientNotificationRepository
    {
        public ClientNotificationRepository(ApplicationDBContext context) : base(context) { }
    }
}
