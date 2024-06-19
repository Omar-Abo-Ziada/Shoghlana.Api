using Shoghlana.Core.Enums;
using Shoghlana.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Shoghlana.Core.DTO
{
    public class ProposalDTO
    {
        //  [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proposal Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Proposal Price is required")]
        public decimal Price { get; set; }

        public ProposalStatus Status { get; set; } = ProposalStatus.Waiting;

        //---------------------------------

        public int? FreelancerId { get; set; }

        public int? JobId { get; set; }
    }
}