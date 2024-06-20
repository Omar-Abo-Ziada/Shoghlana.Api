using Shoghlana.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Link { get; set; }

        public byte[] Poster { get; set; }

        public List<ProjectImages>? Images { get; set; } = new List<ProjectImages> { }; 

        public List<ProjectSkills>? Skills { get; set; } = new List<ProjectSkills> { };

        public DateTime? TimePublished { get; set; } = DateTime.Now;

        //---------------------------------------------------

        public int? FreelancerId { get; set; }

        public Freelancer Freelancer { get; set; }
    }
}