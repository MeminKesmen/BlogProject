using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private IBlogService _blogService;
        public BlogController()
        {
            _blogService = new BlogManager(new EfBlogDal());
        }
        public IActionResult Index(string search="",int page=1)
        {
            var blogList = _blogService.GetListWithCategory(b=>b.BlogTitle.Contains(search)).ToPagedList(page, 10);
            return View(blogList);
        }
        public IActionResult BlogDelete(int id)
        {
            var blog = _blogService.Get(b=>b.BlogId==id);//null kontrol ve alert
            _blogService.Delete(blog);
            return RedirectToAction("Index");
        }
    }
}
