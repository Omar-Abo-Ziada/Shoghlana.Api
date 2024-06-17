using AutoMapper;
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
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            return categoryService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            return categoryService.GetById(id);
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

            return categoryService.CreateCategory(getTitleofCategoryDTO);
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

            return categoryService.CreateCategory(getTitleofCategoryDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult<GeneralResponse> DeleteCategory(int id)
        {
            return categoryService.DeleteCategory(id);
        }
    }
}