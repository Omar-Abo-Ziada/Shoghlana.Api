using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Implementaions
{
    public class SkillService : GenericService<Skill>, ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public SkillService(IUnitOfWork unitOfWork, IGenericRepository<Skill> genericRepository, IMapper mapper) 
                                                   : base(unitOfWork, genericRepository)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task <GeneralResponse> GetAllAsync() 
        {
          IEnumerable<Skill> Skills = await _unitOfWork.skillRepository.FindAllAsync();
            if(Skills.Count() == 0)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "No skills found"
                };
            }
            List<SkillDTO> SkillDTOs = mapper.Map<List<Skill>, List<SkillDTO>>(Skills.ToList());

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = SkillDTOs,
                Message = "Skills were retrieved successfully"
            };
        }


        public async Task<GeneralResponse> GetByIdAsync(int id) 
        {
            Skill? skill = await _unitOfWork.skillRepository
                                 .FindAsync(criteria: s => s.Id == id);

            if(skill is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "No skill with this id"
                };
            }

            SkillDTO SkillDto = mapper.Map<Skill, SkillDTO>(skill);

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = SkillDto,
                Message = "Skill retrieved successfully"
            };
        }
    }
}
