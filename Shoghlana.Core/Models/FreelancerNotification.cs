﻿namespace Shoghlana.Core.Models
{
    public class FreelancerNotification
    {
        public int Id { get; set; }

        public int FreelancerId { get; set; }

        public Freelancer Freelancer { get; set; }

        public string Title { get; set; }

        public DateTime sentTime { get; set; }

        public string description { get; set; }
    }
}