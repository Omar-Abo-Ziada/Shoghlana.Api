using System.ComponentModel.DataAnnotations.Schema;

namespace Shoghlana.Core.Models
{
    public class ProjectSkills
    {
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [ForeignKey("Skill")]
        public int SkillId { get; set; }

        public Skill Skill { get; set; }
    }
}