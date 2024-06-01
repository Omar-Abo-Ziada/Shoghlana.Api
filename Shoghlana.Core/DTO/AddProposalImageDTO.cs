using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.DTO
{
    public class AddProposalImageDTO
    {
        //public int Id { get; set; }

        public IFormFile? Image { get; set; }

        //--------------------------------

        public int ProposalId { get; set; } 

        //public Proposal Proposal { get; set; }
    }
}
