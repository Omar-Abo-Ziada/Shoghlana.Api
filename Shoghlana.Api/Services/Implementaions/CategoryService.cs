using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Implementaions
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> repository, IMapper mapper)
            : base(unitOfWork, repository)
        {
            this.mapper = mapper;
        }

        //********************************************************************

        public ActionResult<GeneralResponse> GetAll()
        {
            IEnumerable<Category> categories = _unitOfWork.categoryRepository.FindAll();

            if (categories != null)
            {
                List<GetTitleofCategoryDTO> categoryDTOs = new List<GetTitleofCategoryDTO>();
                foreach (Category category in categories)
                {
                    GetTitleofCategoryDTO categoryDTO = mapper.Map<GetTitleofCategoryDTO>(category);
                    categoryDTOs.Add(categoryDTO);
                }

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 200,
                    Data = categoryDTOs
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 400,
                Message = "There is no categories",
            };
        }

        public ActionResult<GeneralResponse> GetById(int id)
        {
            Category? category = _unitOfWork.categoryRepository.GetById(id);

            if (category != null)
            {
                CategoryDTO categoryDTO = mapper.Map<CategoryDTO>(category);

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 200,
                    Data = categoryDTO
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 400,
                Message = "Category Not Found !"
            };
        }

        public ActionResult<GeneralResponse> CreateCategory(GetTitleofCategoryDTO getTitleofCategoryDTO)
        {
            Category category = mapper.Map<Category>(getTitleofCategoryDTO);

            _unitOfWork.categoryRepository.Add(category);

            _unitOfWork.Save();

            CategoryDTO categoryDTO = mapper.Map<CategoryDTO>(category);

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 201,
                Data = categoryDTO,
                Message = "Category created successfully"
            };
        }

        public ActionResult<GeneralResponse> UpdateCategory(int id, GetTitleofCategoryDTO getTitleofCategoryDTO)
        {
            Category? category = _unitOfWork.categoryRepository.GetById(id);

            if (category != null)
            {
                mapper.Map(getTitleofCategoryDTO, category);

                _unitOfWork.categoryRepository.Update(category);

                _unitOfWork.Save();

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 200,
                    Message = "Category updated successfully"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 404,
                Message = "Category Not Found!"
            };
        }

        public ActionResult<GeneralResponse> DeleteCategory(int id)
        {
            Category? category = _unitOfWork.categoryRepository.GetById(id);

            if (category != null)
            {
                _unitOfWork.categoryRepository.Delete(category);

                _unitOfWork.Save();

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Status = 200,
                    Message = "Category deleted successfully"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = false,
                Status = 404,
                Message = "Category Not Found!"
            };
        }
    }
}