using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime RegisterationTime { get; set; }
        public string? Description { get; set; }

        public byte[]? Image { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public List<Job>? Jobs { get; set; } = new List<Job>();

        [NotMapped]
        public int JobsCount => Jobs.Count;
        [NotMapped]
        public int CompletedJobsCount => Jobs.Where(j => j.Status == Enums.JobStatus.completed).Count();

        public ApplicationUser? User { get; set; }

        public List<ClientNotification>? Notifications { get; set; }
    }
}