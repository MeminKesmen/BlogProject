using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class ContactController : Controller
    {
        private IContactService _contactService;
        public ContactController()
        {
            _contactService = new ContactManager(new EfContactDal());
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactDate = DateTime.Now;
            contact.ContactStatus = true;
            _contactService.Add(contact);
            return RedirectToAction("Index","Blog");
        }
    }
}
