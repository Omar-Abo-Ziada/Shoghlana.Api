using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class Freelancer
    {
        [Key]
        public int Id { get; set; }

        public string? PersonalImage { get; set; }

        public string? Name { get; set; }

        public string? Title { get; set; }

        public string? Address { get; set; }

        public string? Overview { get; set; }

        public List<Project>? Portfolio { get; set; }

        public List<Job>? WorkingHistory { get; set; }

        public List<Proposal>? Proposals { get; set; }

        public List<FreelancerSkills>? Skills { get; set; }
    }
}
