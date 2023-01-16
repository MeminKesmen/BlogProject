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
    public class ContactController : Controller
    {
        private IContactService _contactService;
        public ContactController()
        {
            _contactService = new ContactManager(new EfContactDal());
        }
        public IActionResult Index(int page=1)
        {
            var contactLit = _contactService.GetAll().ToPagedList(page, 10);
            return View(contactLit);
        }
        public IActionResult ContactDetails(int id)
        {
            var contatc = _contactService.Get(c => c.ContactId == id);
            if (contatc == null) { return RedirectToAction("Index"); }
            return View(contatc);
        }
        public IActionResult ContactDelete(int id)
        {
            var contatc = _contactService.Get(c => c.ContactId == id);
            if (contatc == null) { return RedirectToAction("Index"); }
            _contactService.Delete(contatc);
            return RedirectToAction("Index");
        }

    }
}
