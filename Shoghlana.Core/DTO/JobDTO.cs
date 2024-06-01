using Shoghlana.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.DTO
{
    public class JobDTO
    {
         public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PostTime { get; set; } = DateTime.Now;

        public string Description { get; set; }

      
        public decimal MinBudget { get; set; }

        public decimal MaxBudget { get; set; }

        public ExperienceLevel ExperienceLevel { get; set; }

       
        public List<SkillDTO> skillsDTO { get; set; } = new List<SkillDTO> ();
        public List<FreelancerDTO> freelancersDTO { get; set; } = new List<FreelancerDTO> ();
        public List<ProposalDTO> proposalsDTO { get; set; } = new List<ProposalDTO> ();
   
        public JobStatus Status { get; set; } = JobStatus.Active;



        public int ClientId { get; set; }

        public string? clientName { get; set; }
        public int CategoryId { get; set; }

        public string? categoryTitle { get; set; }

     //   public List<Freelancer>? AppliedFreelancers { get; set; }
    }
}
