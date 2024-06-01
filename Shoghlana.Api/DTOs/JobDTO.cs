using Shoghlana.Core.Enums;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.DTOs
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

        //  public List<Skill>? skills { get; set; }

        //   public List<Proposal>? Proposals { get; set; }

        //   public Rate? Rate { get; set; }
        public Dictionary<int, string> skillsDic { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> freelancerDic { get; set; } = new Dictionary<int, string>(); 
        public Dictionary<int, string> proposalDic { get; set; } = new Dictionary<int, string>();

        public JobStatus Status { get; set; } = JobStatus.Active;



        public int ClientId { get; set; }

        public string? clientName { get; set; }
        public int CategoryId { get; set; }

        public string? categoryTitle { get; set; }

     //   public List<Freelancer>? AppliedFreelancers { get; set; }
    }
}
