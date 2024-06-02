
﻿using AutoMapper;
using Shoghlana.Api.DTOs;

using AutoMapper;

using Shoghlana.Core.DTO;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Freelancer, FreelancerDTO>();
            CreateMap<FreelancerDTO, Freelancer>();

            CreateMap<SkillDTO, Skill>();
            CreateMap<Skill, SkillDTO>();


            CreateMap<SkillsDTO, Skill>();
            CreateMap<Skill, SkillsDTO>();

            CreateMap<Rate , RateDTO>();
            CreateMap<RateDTO, Rate>();


            CreateMap<Job, JobDTO>(); 
            CreateMap<JobDTO, Job>();

            CreateMap<GetProposalDTO, Proposal>();
            CreateMap<Proposal, GetProposalDTO>();

            CreateMap<ProposalImages, GetProposalImageDTO>();
            CreateMap<GetProposalImageDTO, ProposalImages>();

        }
    }
}