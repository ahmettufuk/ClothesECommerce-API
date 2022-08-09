using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("getcomments")]
        public IActionResult GetComments()
        {
            var result = _commentService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult CommentAdd(Comment comment)
        {
            var result = _commentService.Add(comment);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult CommentDelete(Comment comment)
        {
            var result = _commentService.Delete(comment);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult CommentUpdate(Comment comment)
        {
            var result = _commentService.Update(comment);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
