﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Models
{
    public class Freelancer 
    {
          [Key]
        public int Id { get; set; }

        //public string? PersonalImage { get; set; }

        public byte[]? PersonalImageBytes { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string? Address { get; set; }

        public string? Overview { get; set; }

        public List<Project>? Portfolio { get; set; }   

        public List<Job>? WorkingHistory { get; set; }

        public List<Proposal>? Proposals { get; set; }

        public List<FreelancerSkills>? Skills { get; set; }

        public List<FreelancerNotification>? Notifications { get; set; }

        public ApplicationUser? User { get; set; }

        ///TODO : add service from freelancer

        // list<Notification> notifications {get; set;}  >> time , desc "url" navigate to dif pages
        // ai guide client how write requirements , recommend freelancers  
        // freelancer skills, job skills >> m:m
        // inherit from identityUser 
        // add skills and level bsaed on quick exam  >> timer , retake the exam after period of time for score enhancement
        // ai help client add related skills based on his desc
        // more matched skills >> high chance for recommendation and being one of the first prposals to be displayed

    }
}
