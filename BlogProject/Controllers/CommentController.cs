using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ViewModels;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
       private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(CommentRequestViewModel comment)
        {
            if (!ModelState.IsValid) { return RedirectToAction("BlogReadAll", "Blog", new { id = comment.BlogId }); }

            _commentService.Add(new Comment
            {
                CommentUserName = comment.CommentUserName,
                CommentTitle = comment.CommentTitle,
                CommentContent = comment.CommentContent,
                BlogScore = comment.BlogScore,
                BlogId = comment.BlogId
            });
            return RedirectToAction("BlogReadAll", "Blog", new { id = comment.BlogId });
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var comments = _commentService.GetAll(c => c.BlogId == id);
            return PartialView(comments);
        }
    }
}
