using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error(int code)
        {
            return View();
        }
    }
}
