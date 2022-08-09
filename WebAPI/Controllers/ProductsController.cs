using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public ProductsController(IProductService productService,IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

        [HttpGet("getproducts")]
        public IActionResult GetProduct()
        {
            var result = _productService.GetProductsDetails();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getproductsbyname")]
        public IActionResult GetProductsByName(string name)
        {
            var result = _productService.GetProductByName(name);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpGet("getproductsbyid")]
        public IActionResult GetProductsByName(int id)
        {
            var result = _productService.GetProductsById(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getproductsbycategory")]
        public IActionResult getProductsByCategory(int id)
        {
            var result = _productService.GetProductByCategory(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpGet("getproductsbybrand")]
        public IActionResult getProductsByBrand(int id)
        {
            var result = _productService.GetProductByBrand(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getproductsbycolour")]
        public IActionResult getProductsByColour(int id)
        {
            var result = _productService.GetProductByColour(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult ProductAdd(Product product)
        {
            var result = _productService.Add(product);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult ProductDelete(Product product)
        {
            var result = _productService.Delete(product);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult ProductUpdate(Product product)
        {
            var result = _productService.Update(product);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
