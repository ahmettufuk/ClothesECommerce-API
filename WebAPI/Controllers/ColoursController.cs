using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoursController : ControllerBase
    {
        private IColourService _colourService;

        public ColoursController(IColourService colourService)
        {
            _colourService = colourService;
        }

        [HttpGet("getcolours")]
        public IActionResult GetColours()
        {
            var result = _colourService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult ColourAdd(Colour colour)
        {
            var result = _colourService.Add(colour);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult ColourDelete(Colour colour)
        {
            var result = _colourService.Delete(colour);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult ColourUpdate(Colour colour)
        {
            var result = _colourService.Update(colour);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
