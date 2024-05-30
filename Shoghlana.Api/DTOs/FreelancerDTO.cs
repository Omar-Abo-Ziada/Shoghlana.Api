﻿using Shoghlana.Core.Models;

namespace Shoghlana.Api.DTOs
{
    public class FreelancerDTO
    {
        // I don't need ID in dto because it's auto generated by EF
        //public int Id { get; set; }

        //public string? PersonalImage { get; set; }

        public byte[]? PersonalImageBytes { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string? Address { get; set; }

        public string? Overview { get; set; }

        //public List<Project>? Portfolio { get; set; }

        //public List<Job>? WorkingHistory { get; set; }

        //public List<Proposal>? Proposals { get; set; }

        public List<SkillsDTO>? skills { get; set; }

        //public List<Notification>? notifications { get; set; }
    }
}
