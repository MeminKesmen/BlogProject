using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Utilities;
using BusinessLayer.Concrete;
using BusinessLayer.Utilities;
using BusinessLayer.ViewModels;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IWriterService _writerService;
        private IWriterRoleService _writerRoleService;
        private IImageService _imageService;
        public AccountController(IWriterService writerService, IWriterRoleService writerRoleService, IImageService imageService)
        {
            //_writerService = new WriterManager(new EfWriterDal(), new EfBlogDal());
            //_writerRoleService = new WriterRoleManager(new EfWriterRoleDal());
            //_imageService = new ImageManager();
            _writerService = writerService;
            _writerRoleService = writerRoleService;
            _imageService = imageService;

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
                return View();
            }//boş geçilemez
            var findWriter = _writerService.GetWriterWithRoles(w => w.WriterMail == user.Mail && w.WriterPassword == user.Password);
            if (findWriter != null)
            {
                await HttpContext.SignOutAsync();
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, findWriter.WriterName));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, findWriter.WriterId.ToString()));
                claims.Add(new Claim(ClaimTypes.Email, findWriter.WriterMail));
                foreach (var role in findWriter.WriterRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Role.RoleName));
                }
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "DashBoard");
            }

            ModelState.AddModelError("login", "Giriş bilgileriniz kontrol ediniz!");
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            // HttpContext.Session.SetString("listeId", "");
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(WriterProfile writerProfile)
        {
            if (!ModelState.IsValid) { return View(); }
            Writer writer = new Writer();
            if (writerProfile.WriterImage != null)
            {
                writer.WriterImage = _imageService.SaveImage(writerProfile.WriterImage, "WriterImages");
            }
            writer.WriterMail = writerProfile.WriterMail;
            writer.WriterName = writerProfile.WriterName;
            writer.WriterPassword = writerProfile.WriterPassword;
            writer.WriterAbout = writerProfile.WriterAbout;

            _writerService.Add(writer);
            _writerRoleService.Add(new WriterRole { RoleId = 2, WriterId = writer.WriterId });
            return RedirectToAction("Login");
        }
    }
}
