using AutoMapper;
using Shoghlana.Api.DTOs;
using Shoghlana.Core.Models;

namespace Shoghlana.Api
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<List<Job>, List<JobDTO>>();
            CreateMap<List<JobDTO>, List<Job>>(); 
            CreateMap<Job, JobDTO>();
            CreateMap<JobDTO, Job>();

        }
    }
}
