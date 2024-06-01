using Shoghlana.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class Job
    {
       // [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PostTime { get; set; }

        public string Description { get; set; }

      //  [Column(TypeName = "Money")]
        public decimal MinBudget { get; set; }

       // [Column(TypeName = "Money")]
        public decimal MaxBudget { get; set; }

        public ExperienceLevel ExperienceLevel { get; set; }

        public List<JobSkills> skills { get; set; } = new List<JobSkills>();

        public List<Proposal>? Proposals { get; set; } = new List<Proposal>();

        public Rate? Rate { get; set; }

        public JobStatus Status { get; set; }
        //public JobStatus Status { get; set; } = JobStatus.Active;

        //---------------------------------------------

      //  [ForeignKey("Client")]
        public int? ClientId { get; set; }

        public Client Client { get; set; }

      //  [ForeignKey("Freelancer")]
        public int? FreelancerId { get; set; }

        public Freelancer Freelancer { get; set; }


    //    [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}