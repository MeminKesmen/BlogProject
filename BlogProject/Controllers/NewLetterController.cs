using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class NewLetterController : Controller
    {
        private IMailNewsLetterService _mailNewsLetterService;
        public NewLetterController()
        {
            _mailNewsLetterService = new MailNewsLetterManager(new EfMailNewsLetterDal());
        }
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(MailNewsLetter mailNewsLetter)
        {
            mailNewsLetter.MailStatus = true;
            _mailNewsLetterService.Add(mailNewsLetter);
            return PartialView();
        }
    }
}
