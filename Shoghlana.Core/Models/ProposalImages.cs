using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class ProposalImages
    {
        public int Id { get; set; }

        [ForeignKey("Proposal")]
        public int ProposalId { get; set; }

        public Proposal Proposal { get; set; }

        public byte[] Image { get; set; }
    }
}