using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
