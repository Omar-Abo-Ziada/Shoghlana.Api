using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Shoghlana.Core.DTO
{
    public class AddProjectDTO
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters long")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string? Title { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        public string? Link { get; set; }

        [Required(ErrorMessage = "Poster is required")]
        public IFormFile Poster { get; set; }

        public List<ImageDTO>? Images { get; set; } = new List<ImageDTO> { };

        //public List<SkillDTO>? Skills { get; set; } = new List<SkillDTO> { };

        public List<int>? SkillIDs { get; set; } = new List<int> { };

        public DateTime? TimePublished { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "FreelancerId is required")]
        public int FreelancerId { get; set; }

        [Required(ErrorMessage = "ProjectId is required")]
        public int ProjectId { get; set; }
    }
}