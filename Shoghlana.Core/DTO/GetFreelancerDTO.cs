﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.DTO
{
    public class GetFreelancerDTO
    {
        // I don't need ID in dto because it's auto generated by EF >> when send freelancer to front as dto , we want to send its id 
        public int Id { get; set; }

        //public string? PersonalImage { get; set; }

        public byte[]? PersonalImageBytes { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string? Address { get; set; }

        public string? Overview { get; set; }

        // should be uncommented and optional >> added on edit freelancer profile >> not added on freelancer creation >> use projectdto on adding , getprojectdto onretrieving

        public List<GetProjectDTO>? Portfolio { get; set; }

        public List<GetJobDTO>? WorkingHistory { get; set; }

        public List<GetProposalDTO>? Proposals { get; set; }

        public List<SkillDTO>? skills { get; set; }

        //public List<Notification>? notifications { get; set; }
    }
}
