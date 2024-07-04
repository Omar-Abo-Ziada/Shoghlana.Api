using Shoghlana.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoghlana.Core.Models
{
    public class Proposal
    {
        public int Id { get; set; }

        public DateTime DeadLine { get; set; } // calulated after approve

        public DateTime? ApprovedTime { get; set; } = null;   // known when the client approves

        public double Duration { get; set; } // given from the freelancer

        public string? Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public ProposalStatus Status { get; set; } = ProposalStatus.Waiting; // not in the DTO >> saeed added it there

        public List<string>? ReposLinks { get; set; }

        //---------------------------------

        public List<ProposalImages>? Images { get; set; }

        public int FreelancerId { get; set; }

        public Freelancer Freelancer { get; set; }

        public int JobId { get; set; }

        public Job Job { get; set; }
    }
}