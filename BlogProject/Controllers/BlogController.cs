using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
