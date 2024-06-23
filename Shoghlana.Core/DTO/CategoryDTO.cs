using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shoghlana.Core.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
   
        public List<AddJobDTO>? Jobs { get; set; }
    }
}