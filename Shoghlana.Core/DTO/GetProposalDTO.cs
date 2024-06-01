using Shoghlana.Core.Enums;
using Shoghlana.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Shoghlana.Core.DTO
{
    public class GetProposalDTO
    {
        public int Id { get; set; }

        public DateTime DeadLine { get; set; } // calulated after approve

        public DateTime ApprovedTime { get; set; } // known when the client approves

        public double Duration { get; set; } // given from the freelancer

        public string? Description { get; set; } 

        public decimal Price { get; set; }

        //public ProposalStatus Status { get; set; } // not in the get DTO but assigned from backend when adding a proposal

        public List<string>? ReposLinks { get; set; }

        //---------------------------------

        //public List<ProposalImages>? Images { get; set; }

        public List<GetProposalImageDTO>? Images { get; set; }

        public int FreelancerId { get; set; }

        //public Freelancer Freelancer { get; set; }

        public int? JobId { get; set; }

        //public Job Job { get; set; }
    }
}