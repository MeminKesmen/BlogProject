using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Blog
{
    public class BlogListDashBoard:ViewComponent
    {
        IBlogService _blogService;
        public BlogListDashBoard()
        {
            _blogService = new BlogManager(new EfBlogDal());
        }
        public IViewComponentResult Invoke()
        {
            var blogs = _blogService.GetListWithCategory(count:5);
            return View(blogs);
        }
    }
}
