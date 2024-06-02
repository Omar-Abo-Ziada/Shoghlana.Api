using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.DTO
{
    public class GetProposalImageDTO
    {
        public int Id { get; set; } 

        public byte[] Image { get; set; }

        //--------------------------------

        public int ProposalId { get; set; }

        //public Proposal Proposal { get; set; }
    }
}