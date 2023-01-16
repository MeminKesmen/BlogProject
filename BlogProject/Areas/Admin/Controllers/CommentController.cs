using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private ICommentService _commentService;
        public CommentController()
        {
            _commentService = new CommentManager(new EfCommentDal());
        }

        public IActionResult Waiting(int page = 1)
        {
            var waitingComments = _commentService.GetAll(c => c.CommentStatus == false).ToPagedList(page, 20);
            return View("Index", waitingComments);
        }
        public IActionResult Approved(int page = 1)
        {
            var approvedComments = _commentService.GetAll(c => c.CommentStatus == true).ToPagedList(page, 20);
            return View("Index", approvedComments);
        }
        public IActionResult CommentActivate(int id)
        {
            var comment = _commentService.Get(c => c.CommentId == id);
            if (comment == null) { RedirectToAction("Index"); }//bulunamadı
            comment.CommentStatus= !comment.CommentStatus;
            _commentService.Update(comment);
            return RedirectToAction("Index");
        }
        public IActionResult CommentDelete(int id, int page = 1)
        {
            var comment = _commentService.Get(c => c.CommentId == id);
            string action = "Waiting";
            if (comment != null)
            {
                action = comment.CommentStatus ? "Approved" : action;
                _commentService.Delete(comment);
            }
            return RedirectToAction(action, new { page });
        }
        public IActionResult CommentDetail(int id)
        {
            var comment=_commentService.Get(c=>c.CommentId==id);
            if (comment==null) { return RedirectToAction("Waiting"); }
            return View(comment);
        }
    }
}
