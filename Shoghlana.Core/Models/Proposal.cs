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
    public class Proposal
    {
      //  [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

     //   [Column(TypeName = "Money")]
        public decimal Price { get; set; }

       // public ProposalStatus Status { get; set; } = ProposalStatus.Waiting;
        public ProposalStatus Status { get; set; }

        //---------------------------------

      //  [ForeignKey("Freelancer")]
        public int? FreelancerId { get; set; }

        public Freelancer Freelancer { get; set; }


      //  [ForeignKey("Job")]
        public int? JobId { get; set; }

        public Job Job { get; set; }
    }
}
//sdasd