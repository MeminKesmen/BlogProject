using BlogProject.Generic;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    [Authorize(Roles = "Writer")]
    public class DashBoardController : MyController
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;
        public DashBoardController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var user = GetCurrentUser();
            ViewBag.BlogCount = _blogService.Count();
            ViewBag.MyBlogCount = _blogService.Count(b=>b.WriterId==user.UserId);
            ViewBag.CategoryCount = _categoryService.Count(c=>c.CategoryStatus==true);
            return View();
        }
    }
}
