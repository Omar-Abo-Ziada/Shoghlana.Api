using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.DTO
{
    public class GetImageDTO
    {
        [Required(ErrorMessage = "Image is required")]
        public byte[] Image { get; set; }

        public int? ProjectId { get; set; }
    }
}