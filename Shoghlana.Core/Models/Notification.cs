using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public DateTime sentTime { get; set; }
         
        public string description { get; set; }

        //--------------------------------------------

        public List<FreelancerNotification>? FreelancerNotifications { get; set; }

        public List<ClientNotification>? ClientNotifications { get; set; }
    }
}