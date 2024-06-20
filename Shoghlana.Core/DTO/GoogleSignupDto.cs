using Shoghlana.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.DTO
{
    public class GoogleSignupDto
    {

        public string id { get; set; } 
        public string email { get; set; } 
        public string idToken { get; set; } 
      //  public string name { get; set; } 
        public string? photoUrl { get; set; }
        public string firstName { get; set; }
        public int role { get; set; }
    }
}
