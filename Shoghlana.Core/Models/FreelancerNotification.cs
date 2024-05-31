using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class FreelancerNotification
    {
        public int FreelancerId { get; set; }

        public Freelancer Freelancer { get; set; }

        public int NotificationId { get; set; }

        public Notification Notification { get; set; }
    }
}
