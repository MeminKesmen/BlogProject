using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class AboutController : Controller
    {
        private IAboutService _aboutService;
        public AboutController()
        {
            _aboutService = new AboutManager(new EfAboutDal());
        }
        public IActionResult Index()
        {
           var about= _aboutService.Get(a=>a.AboutId==1);
            return View(about);
        }
    }
}
