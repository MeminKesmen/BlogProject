using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Blog
{
    public class WriterLastBlog:ViewComponent
    {
        IBlogService _blogService;
        public WriterLastBlog()
        {
            _blogService = new BlogManager(new EfBlogDal());
        }
        public IViewComponentResult Invoke(int id)
        {
            int count = 3;
            var blogs = _blogService.GetListByCount(b=>b.WriterId==id,count);
            return View(blogs);
        }
    }
}
