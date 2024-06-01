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

            CreateMap<Job, JobDTO>(); 
            CreateMap<JobDTO, Job>();

            CreateMap<GetProposalDTO, Proposal>();
            CreateMap<Proposal, GetProposalDTO>();

            CreateMap<ProposalImages, GetProposalImageDTO>();
            CreateMap<GetProposalImageDTO, ProposalImages>();
        }
    }
}