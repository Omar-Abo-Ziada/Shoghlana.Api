using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repository;

namespace Shoghlana.EF.Repositories
{
    public class FreelancerNotificationRepository : GenericRepository<FreelancerNotification>, IFreelancerNotificationRepository
    {
        public FreelancerNotificationRepository(ApplicationDBContext context) : base(context) { }
    }
}
