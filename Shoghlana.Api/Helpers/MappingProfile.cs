
﻿using AutoMapper;

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


            CreateMap<SkillDTO, Skill>();
            CreateMap<Skill, SkillDTO>();

            CreateMap<Rate , RateDTO>();
            CreateMap<RateDTO, Rate>();


            CreateMap<Job, JobDTO>(); 
            CreateMap<JobDTO, Job>();

            CreateMap<GetProposalDTO, Proposal>();
            CreateMap<Proposal, GetProposalDTO>();


            CreateMap<ProposalDTO, Proposal>();
            CreateMap<Proposal, ProposalDTO>();

            CreateMap<ProposalImages, GetProposalImageDTO>();
            CreateMap<GetProposalImageDTO, ProposalImages>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, GetTitleofCategoryDTO>();
            CreateMap<GetTitleofCategoryDTO, Category>();
        }
    }
}