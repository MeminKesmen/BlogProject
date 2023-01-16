using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProject.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        IBlogService _blogService;
        public WriterLastBlog()
        {
            _blogService = new BlogManager(new EfBlogDal());
        }
        public IViewComponentResult Invoke(int id)
        {
           
            var blogs = _blogService.GetListByCount(b => b.WriterId == id, 3);
            return View(blogs);
        }
    }
}
