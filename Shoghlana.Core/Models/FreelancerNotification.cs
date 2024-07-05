using Shoghlana.Core.Enums;

namespace Shoghlana.Core.Models
{
    public class FreelancerNotification
    {
        public int Id { get; set; }

        public int FreelancerId { get; set; }

        public Freelancer Freelancer { get; set; }

        public string Title { get; set; }

        public DateTime sentTime { get; set; }

        public string description { get; set; }

        public NotificationReason Reason { get; set; }
        public int? NotificationTriggerId { get; set; } // saeed: represent id of job you are accepted on , id of user that sent you a message >> used in front to pass in route of the component which will be openend on clicking on tha notification
    }
}