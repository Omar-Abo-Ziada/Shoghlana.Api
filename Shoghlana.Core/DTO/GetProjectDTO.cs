using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.DTO
{
    public class GetProjectDTO
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters long")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        public string? Link { get; set; }

        [Required(ErrorMessage = "Poster is required")]
        public byte[] Poster { get; set; }

        public List<GetImageDTO>? Images { get; set; }

        public List<SkillDTO>? Skills { get; set; }

        public DateTime? TimePublished { get; set; }

        public int? FreelancerId { get; set; }

    }
}
