using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Blog
{
    public class LastPosts : ViewComponent
    {
        IBlogService _blogService;
        public LastPosts()
        {
            _blogService = new BlogManager(new EfBlogDal());
        }
        public IViewComponentResult Invoke()
        {
            var blogs = _blogService.GetListByCount(count: 3);
            return View(blogs);
        }
    }
}
