using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private IAboutService _aboutService;
        public AboutController()
        {
            _aboutService = new AboutManager(new EfAboutDal());
        }
        public IActionResult Index()
        {
            var about = _aboutService.Get(a=>a.AboutId==1);
            return View(about);
        }
        [HttpPost]
        public IActionResult Index(About about)
        {
            if (!ModelState.IsValid) { return View(); }
            var findAbout = _aboutService.Get(a => a.AboutId == 1);
            findAbout.AboutDetails = about.AboutDetails;
            return View(about);
        }

    }
}
