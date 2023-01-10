using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProject.Controllers
{
    public class LoginController : Controller
    {
        private IWriterService _writerService;
        public LoginController()
        {
            _writerService = new WriterManager(new EfWriterDal());
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Writer writer)
        {
            var user = _writerService.Get(w => w.WriterMail == writer.WriterMail && w.WriterPassword == writer.WriterPassword);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,writer.WriterMail)
                };
                var userIdentity = new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "DashBoard");
            }
            return View();
        }
    }
}
//var user = _writerService.Get(w => w.WriterMail == writer.WriterMail && w.WriterPassword == writer.WriterPassword);
//if (user != null)
//{
//    HttpContext.Session.SetString("user", writer.WriterMail);
//    return RedirectToAction("Index", "Writer");
//}
//return View();