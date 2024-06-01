using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class Admin
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public byte[]? Image { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public ApplicationUser? User { get; set; }
    }
}
