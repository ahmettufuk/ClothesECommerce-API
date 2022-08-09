using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private ISizeService _sizeService;

        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet("getsizes")]
        public IActionResult GetSizes()
        {
            var result = _sizeService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult SizeAdd(Size size)
        {
            var result = _sizeService.Add(size);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult SizeDelete(Size size)
        {
            var result = _sizeService.Delete(size);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult SizeUpdate(Size size)
        {
            var result = _sizeService.Update(size);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
