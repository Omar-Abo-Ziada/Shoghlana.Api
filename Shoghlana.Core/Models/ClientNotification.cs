namespace Shoghlana.Core.Models
{
    public class ClientNotification
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public string Title { get; set; }

        public DateTime sentTime { get; set; }

        public string description { get; set; }
    }
}