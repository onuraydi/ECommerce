using ECommercial.Comment.Context;
using ECommercial.Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommercial.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentContext.UserComments.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _commentContext.UserComments.Add(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _commentContext.UserComments.Update(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            _commentContext.UserComments.Remove(value);
            _commentContext.SaveChanges();
            return Ok("Yorum Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var values = _commentContext.UserComments.Find(id);
            return Ok(values);
        }

        [HttpGet("CommentListByProductId")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _commentContext.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(value);
        }
    }
}
