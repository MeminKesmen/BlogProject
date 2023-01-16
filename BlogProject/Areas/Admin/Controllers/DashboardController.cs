using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Writer")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
    
}
