using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.DTO
{
    public class NotificationDTO
    {
        public string Title { get; set; }
        public DateTime sentTime { get; set; }

        public string description { get; set; }


        public string senderName { get; set; }
        public byte[]? senderImage { get; set; }


    }
}
