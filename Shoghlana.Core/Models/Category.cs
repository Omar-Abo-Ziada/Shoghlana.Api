using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public List<Job>? Jobs { get; set; }
    }
}
