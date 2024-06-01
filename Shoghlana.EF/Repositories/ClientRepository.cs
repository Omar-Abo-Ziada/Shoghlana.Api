using Microsoft.EntityFrameworkCore;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.EF.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDBContext context) : base(context)
        {
            
        }

        public Client ? GetClientWithJobs(int id)
        {
            return context.Clients
                .Include(x => x.Jobs)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
