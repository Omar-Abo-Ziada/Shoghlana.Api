using AutoMapper;
using Shoghlana.Api.DTOs;
using Shoghlana.Core.Models;

namespace Shoghlana.Api
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<Job, JobDTO>();
            CreateMap<JobDTO, Job>();

        }
    }
}
