using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Entity.DTOs.AccountDTO;
using MobileShop.Entity.DTOs.CategoryDTO;
using MobileShop.Service;

namespace MobileShop.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost("add-category")]
        public IActionResult AddCategory([FromBody] CreateCategoryRequest category)
        {
            var result = _categoryService.AddCategory(category);
            if (result == null)
            {
                return StatusCode(500);
            }
            return Ok(result);
        }

        [HttpGet("get-all-category")]
        public IActionResult GetAllCategory()
        {

            var categories = _categoryService.GetAllCategory();
            if (categories != null && categories.Count == 0)
            {
                return Ok("Don't have category");
            }
            return Ok(categories);
        }

        [HttpGet("get-category-id/{id}")]
        public IActionResult GetAccountById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound("Category does not exist");
            }
            return Ok(category);
        }

        [HttpPut("put-category")]
        public IActionResult UpdateCategory(UpdateCategoryRequest category)
        {
            var result = _categoryService.UpdateCategory(category);
            if (result == null)
            {
                return StatusCode(500);
            }
            return Ok(result);
        }

        [HttpDelete("delete-category/{id}")]
        public IActionResult DeleteAccount(int id)
        {
            var result = _categoryService.UpdateDeleteStatusCategory(id);
            if (result == false)
            {
                return StatusCode(500);
            }
            return Ok("Delete category complete");
        }
    }
}
