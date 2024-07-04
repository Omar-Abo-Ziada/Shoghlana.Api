namespace Shoghlana.Core.DTO
{
    public class GetClientNotificationsDTO
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        //public Client Client { get; set; }

        public string Title { get; set; }

        public DateTime sentTime { get; set; }

        public string description { get; set; }
    }
}