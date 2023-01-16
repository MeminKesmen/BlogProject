using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class NewLetterController : Controller
    {
        private IMailNewsLetterService _mailNewsLetterService;
        public NewLetterController(IMailNewsLetterService mailNewsLetterService)
        {
            _mailNewsLetterService = mailNewsLetterService;
        }
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeMail(MailNewsLetter mailNewsLetter)
        {
            if (!ModelState.IsValid) { return RedirectToAction("BlogReadAll", "Blog"); }
            _mailNewsLetterService.Add(mailNewsLetter);
            return PartialView();
        }
    }
}
