using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class ClientNotification
    {
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime sentTime { get; set; }

        public string description { get; set; }
    }
}