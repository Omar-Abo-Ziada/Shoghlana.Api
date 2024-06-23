using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.DTO
{
    public class ClientWithJobsDTO
    {
        public string Name { get; set; }
        public byte[]? Image { get; set; }

        public List<AddJobDTO>? Jobs { get; set; }
    }
}
