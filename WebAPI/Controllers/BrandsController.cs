using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getbrands")]
        public IActionResult GetBrands()
        {
            var result = _brandService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult BrandAdd(Brand brand)
        {
            var result = _brandService.Add(brand);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult BrandDelete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult ProductUpdate(Brand brand)
        {
            var result = _brandService.Update(brand);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

    }
}
