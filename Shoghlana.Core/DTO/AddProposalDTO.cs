using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.DTO
{
    public class AddProposalDTO
    {
        //public int Id { get; set; }

        //public DateTime DeadLine { get; set; } // calulated after approve

        //public DateTime ApprovedTime { get; set; } // known when the client approves

        [Required(ErrorMessage = "Duaration is required")]
        public double Duration { get; set; } // given from the freelancer

        [Required(ErrorMessage = "Description is required")]
        //[StringLength(500 , MinimumLength = 50 , ErrorMessage ="Description has to be from 50 chars upto 500 chars")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        //public ProposalStatus Status { get; set; } // not in the get DTO but assigned from backend when adding a proposal

        public List<string>? ReposLinks { get; set; }

        //---------------------------------

        //public List<ProposalImages>? Images { get; set; }

        public List<AddProposalImageDTO>? Images { get; set; }

        public int FreelancerId { get; set; }

        //public Freelancer Freelancer { get; set; }

        public int JobId { get; set; }

        //public Job Job { get; set; }
    }
}