using Shoghlana.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.DTO
{
    public class GetJobDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PostTime { get; set; } = DateTime.Now;

        //public DateTime? ApproveTime { get; set; } // added manually when the client accept a proposal

        public string Description { get; set; }

        public decimal MinBudget { get; set; }

        public decimal MaxBudget { get; set; }

        public int DurationInDays { get; set; }

        //public DateTime? DeadLine { get; set; }

        public ExperienceLevel ExperienceLevel { get; set; }

        public List<SkillDTO>? Skills { get; set; } = new List<SkillDTO>();

        //public List<GetProposalDTO>? Proposals { get; set; } = new List<GetProposalDTO>();

        /// <summary>
        ///  any time you access the readonly ProposalsCount property,
        ///  it will always return the current count of the Proposals list.
        ///  shorlty like this using Lampda expression : 
        /// </summary>  
        //public int? ProposalsCount
        //{
        //    get => Proposals?.Count() ?? 0;
        //    // who ever deals with it from front can't set this value ,, it has only setter in the model itself
        //   // set => ProposalsCount = value;
        //}

        //public JobStatus Status { get; set; } = JobStatus.Active;

        public int ClientId { get; set; }

        //public string clientName { get; set; }

        //public int? AcceptedFreelancerId { get; set; }

        //public string? AcceptedFreelancerName { get; set; }

        public int CategoryId { get; set; }

        public string? CategoryTitle { get; set; }

        public RateDTO? Rate { get; set; } // added manually after the freelancer finshes => the client gives him a rate

    }
}
