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

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime sentTime { get; set; }

        public string description { get; set; }
    }
}