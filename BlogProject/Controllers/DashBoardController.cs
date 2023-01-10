using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class DashBoardController : Controller
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;
        public DashBoardController()
        {
            _blogService = new BlogManager(new EfBlogDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }
        public IActionResult Index()
        {
            ViewBag.BlogCount = _blogService.Count();
            ViewBag.MyBlogCount = _blogService.Count(b=>b.WriterId==1);
            ViewBag.CategoryCount = _categoryService.Count();
            return View();
        }
    }
}
