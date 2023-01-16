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
    public class NewsLetterController : Controller
    {
        private IMailNewsLetterService _newsLetterService;
        public NewsLetterController()
        {
            _newsLetterService = new MailNewsLetterManager(new EfMailNewsLetterDal());
        }
        public IActionResult Index(int page=1)
        {
            var mailList = _newsLetterService.GetAll().ToPagedList(page, 10);
            return View(mailList);
        }
        public IActionResult DeleteMail(int id)
        {
            var mail = _newsLetterService.Get(m=>m.MailId==id);
            if (mail!=null) { _newsLetterService.Delete(mail); }
            return RedirectToAction("Index");
        }
    }
}
