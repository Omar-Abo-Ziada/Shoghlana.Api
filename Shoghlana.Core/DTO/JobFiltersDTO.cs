namespace Shoghlana.Core.DTO
{
    public class JobFiltersDTO
    {
        public decimal MinBudget { get; set; }

        public decimal MaxBudget { get; set; }

        public int CategoryId { get; set; }

        public int ClientId { get; set; }

        public List<string>? SkillsTitles { get; set; } 

        public int? FreelancerId { get; set; }
    }
}