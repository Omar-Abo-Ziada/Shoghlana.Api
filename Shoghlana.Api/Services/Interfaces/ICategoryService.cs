using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Models;

namespace Shoghlana.Api.Services.Interfaces
{
    public interface ICategoryService : IGenericService<Category>
    {
        public ActionResult<GeneralResponse> GetAll();

        public ActionResult<GeneralResponse> GetById(int id);

        public ActionResult<GeneralResponse> CreateCategory(GetTitleofCategoryDTO getTitleofCategoryDTO);

        public ActionResult<GeneralResponse> UpdateCategory(int id, GetTitleofCategoryDTO getTitleofCategoryDTO);

        public ActionResult<GeneralResponse> DeleteCategory(int id);
    }
}