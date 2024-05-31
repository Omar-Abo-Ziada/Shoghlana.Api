using AutoMapper;
using Shoghlana.Api.DTOs;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Freelancer, FreelancerDTO>();
            CreateMap<FreelancerDTO, Freelancer>();

            CreateMap<ProposalDTO, Proposal>();
            CreateMap<Freelancer, ProposalDTO>();

            CreateMap<SkillsDTO, Skill>();
            CreateMap<Skill, SkillsDTO>();
        }
    }
}