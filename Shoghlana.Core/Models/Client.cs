using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class Client 
    {
        [Key]
        //  [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        public byte[]? Image { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public List<Job>? Jobs { get; set; }

        public ApplicationUser? User { get; set; }

        public List<ClientNotification>? Notifications { get; set; }
    }
}