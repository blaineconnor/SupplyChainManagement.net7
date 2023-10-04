using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.DTOs.Categories;
using SCM.Application.Models.RequestModels.Categories;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;

namespace SCM.API.Controllers
{
    [ApiController]
    [Route("category")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("get")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<List<CategoryDTO>>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("get/{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<CategoryDTO>>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(new GetCategoryByIdVM { Id = id });
            return Ok(category);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateCategory(CreateCategoryVM createCategoryVM)
        {
            var categoryId = await _categoryService.CreateCategory(createCategoryVM);
            return Ok(categoryId);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateCategory(int id, UpdateCategoryVM updateCategoryVM)
        {
            if (id != updateCategoryVM.Id)
            {
                return BadRequest();
            }
            var categoryId = await _categoryService.UpdateCategory(updateCategoryVM);
            return Ok(categoryId);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<Result<int>>> DeleteCategory(int id)
        {
            var categoryId = await _categoryService.DeleteCategory(new DeleteCategoryVM { Id = id });
            return Ok(categoryId);
        }

    }
}
