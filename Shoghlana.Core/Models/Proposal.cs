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
        public int Id { get; set; }

        //public string Title { get; set; }

        //TODO duration / deadline 

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public ProposalStatus Status { get; set; } // not in the DTO

        //TODO list of linke of the repo + list of images

        //---------------------------------

        public int? FreelancerId { get; set; }

        public Freelancer Freelancer { get; set; }

        public int? JobId { get; set; }

        public Job Job { get; set; }
    }
}