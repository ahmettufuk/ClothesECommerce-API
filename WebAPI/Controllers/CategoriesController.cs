using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getcategories")]
        public IActionResult GetCategories()
        {
            var result = _categoryService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult CategoryAdd(Category category)
        {
            var result = _categoryService.Add(category);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult CategoryDelete(Category category)
        {
            var result = _categoryService.Delete(category);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult CategoryUpdate(Category category)
        {
            var result = _categoryService.Update(category);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
