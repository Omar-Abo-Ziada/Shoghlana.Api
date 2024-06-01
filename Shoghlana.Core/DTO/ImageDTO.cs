using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace Shoghlana.Core.DTO
{
    public class ImageDTO
    {
        [Required(ErrorMessage = "Image is required")]
        public IFormFile? Image { get; set; }

        public int? ProjectId { get; set; }
    }
}
