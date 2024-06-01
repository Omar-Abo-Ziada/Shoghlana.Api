using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class ProjectImages
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Project")]
        public int? ProjectId { get; set; }

        public Project ?Project { get; set; }

        public byte[] Image { get; set; }
    }
}
