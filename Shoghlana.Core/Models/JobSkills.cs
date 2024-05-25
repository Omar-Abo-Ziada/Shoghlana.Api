using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class JobSkills
    {
       // public int Id { get; set; }

        //----------------------------

        [ForeignKey("Job")]
        public int? JobId { get; set; }

        public Job Job { get; set; }

        [ForeignKey("Skill")]
        public int? SkillId { get; set; }

        public Skill Skill { get; set; }
    }
}
