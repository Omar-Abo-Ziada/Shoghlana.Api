﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Shoghlana.Core.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = " Name Is Required")]
        [MinLength(3, ErrorMessage = "Name must be 3 char at least")]
        public string Name { get; set; }

        public string? Description { get; set; }
        public IFormFile ? Image { get; set; }

        public DateTime RegisterationTime { get; set; } 

        public string? Country { get; set; }

        public string? Phone { get; set; }
        public int JobsCount { get; set; }
        public int CompletedJobsCount { get; set; } 
    }
}
