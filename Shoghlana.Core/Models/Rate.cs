using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class Rate
    {
        [Key]
        public int Id { get; set; }

        public string Feedback { get; set; }

        [Range(1 , 5)]
        public int? Value { get; set; }

        //--------------------------------------

        [ForeignKey("Job")]
        public int? JobId { get; set; }

        public Job Job { get; set; }
    }
}
