using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ViewModels;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
       private ICategoryService _categorService;
        
        public CategoryController(ICategoryService categorService)
        {
            _categorService = categorService;


        }
        public IActionResult Index()
        {
            var categoryList = _categorService.GetListWithBlogCount();

            return View(categoryList);
        }
    }
}
