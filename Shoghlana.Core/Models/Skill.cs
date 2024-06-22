namespace Shoghlana.Core.Models
{
    public class Skill
    {
        public int Id { get; set; } 

        public string Title { get; set; }

        public string? Description { get; set; }

        public List<FreelancerSkills>? freelancers { get; set; }

        public List<JobSkills>? jobs { get; set; }

        public List<ProjectSkills>? projects { get; set; }
    }
}