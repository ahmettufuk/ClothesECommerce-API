using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("getsales")]
        public IActionResult getSaleDetails()
        {
            var result = _saleService.GetAllSaleDetails();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getsalesbycategory")]
        public IActionResult GetSalesByCategory(string name)
        {
            var result = _saleService.GetSaleDetailsByCategory(name);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpGet("getsalesbybrand")]
        public IActionResult GetSalesByBrand(string name)
        {
            var result = _saleService.GetSaleDetailsByBrand(name);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpGet("getsalesbyproduct")]
        public IActionResult GetSalesByProduct(string name)
        {
            var result = _saleService.GetSaleDetailByProduct(name);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult OrderAdd(Sale sale)
        {
            var result = _saleService.Add(sale);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult OrderDelete(Sale sale)
        {
            var result = _saleService.Delete(sale);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult OrderUpdate(Sale sale)
        {
            var result = _saleService.Update(sale);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
