﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Api.Services.Implementaions;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repositories;

namespace Shoghlana.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //Category

        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;

            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            IEnumerable<Category> categories = categoryService.FindAll();

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

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            Category category = categoryService.GetById(id);

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

        [HttpPost]
        public ActionResult<GeneralResponse> CreateCategory(GetTitleofCategoryDTO getTitleofCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "Invalid data!"
                };
            }

            Category category = mapper.Map<Category>(getTitleofCategoryDTO);

            categoryService.Add(category);

            categoryService.Save();

            CategoryDTO categoryDTO = mapper.Map<CategoryDTO>(category);

            return new GeneralResponse()
            {
                IsSuccess = true,
                Status = 201,
                Data = categoryDTO,
                Message = "Category created successfully"
            };
        }

        [HttpPut("{id}")]
        public ActionResult<GeneralResponse> UpdateCategory(int id, GetTitleofCategoryDTO getTitleofCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 400,
                    Message = "Invalid data!"
                };
            }

            Category category = categoryService.GetById(id);
            if (category != null)
            {
                mapper.Map(getTitleofCategoryDTO, category);
                categoryService.Update(category);
                categoryService.Save();

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

        [HttpDelete("{id}")]
        public ActionResult<GeneralResponse> DeleteCategory(int id)
        {
            Category category = categoryService.GetById(id);
            if (category != null)
            {
                categoryService.Delete(category);
                categoryService.Save();

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

