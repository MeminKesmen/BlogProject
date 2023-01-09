using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
