using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class CommentController : Controller
    {
        ICommentService _commentService;

        public CommentController()
        {
            _commentService = new CommentManager(new EfCommentDal());
        }

        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var comments = _commentService.GetAll(c=>c.BlogId==id);
            return PartialView(comments);
        }
    }
}
