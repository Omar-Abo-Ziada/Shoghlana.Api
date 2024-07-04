namespace Shoghlana.Core.DTO
{
    public class GetFreelancerNotificationsDTO
    {
        public int Id { get; set; }

        public int FreelancerId { get; set; }

        //public Freelancer Freelancer { get; set; }

        public string Title { get; set; }

        public DateTime sentTime { get; set; }

        public string description { get; set; }
    }
}