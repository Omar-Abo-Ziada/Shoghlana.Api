using System.ComponentModel.DataAnnotations;

namespace Shoghlana.Core.DTO
{
    public class SkillDTO
    {
        //public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MinLength(1, ErrorMessage = "Title must be at least 1 character long")]
        [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string Title { get; set; }

        [MaxLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
        public string? Description { get; set; }
    }
}