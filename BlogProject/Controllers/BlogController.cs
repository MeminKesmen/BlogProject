using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        IBlogService _blogService;
        public BlogController()
        {
            _blogService = new BlogManager(new EfBlogDal());
        }
        public IActionResult Index()
        {
            var blogs = _blogService.GetListWithCategory();
            return View(blogs);
        }
        public IActionResult BlogReadAll(int id)
        {
            var blog = _blogService.Get(b=>b.BlogId==id);
            return View(blog);
        }
    }
}
