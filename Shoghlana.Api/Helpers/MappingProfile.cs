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

            CreateMap<SkillDTO, JobSkills>();
            CreateMap<JobSkills, SkillDTO>();

            CreateMap<Skill, SkillDTO>();
            CreateMap<SkillDTO, Skill>();

            CreateMap<Project, GetProjectDTO>()
      .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills.Select(ps => ps.Skill)));

            CreateMap<GetProjectDTO, Project>()
                .ForMember(dest => dest.Skills, opt => opt.Ignore());

            CreateMap<Project, AddProjectDTO>();
            CreateMap<AddProjectDTO, Project>();

            CreateMap<ProjectImages, GetImageDTO>();
            CreateMap<GetImageDTO, ProjectImages>();

            CreateMap<Rate, RateDTO>();
            CreateMap<RateDTO, Rate>();

            CreateMap<Job, AddJobDTO>();
            CreateMap<AddJobDTO, Job>();

            CreateMap<GetJobDTO, Job>();
            CreateMap<Job, GetJobDTO>();

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

            CreateMap<FreelancerNotification, GetFreelancerNotificationsDTO>();  
            CreateMap<GetFreelancerNotificationsDTO, FreelancerNotification>();

            CreateMap<ClientNotification, GetClientNotificationsDTO>();
            CreateMap<GetClientNotificationsDTO, ClientNotification>();
        }
    }
}
