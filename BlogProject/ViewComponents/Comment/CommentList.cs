using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Comment
{
    public class CommentList : ViewComponent
    {
        ICommentService _commentService;
        public CommentList()
        {
            _commentService = new CommentManager(new EfCommentDal());
        }
        public IViewComponentResult Invoke(int id)
        {
            var comments = _commentService.GetAll(c => c.BlogId == id);
            return View(comments);
        }
    }
}
