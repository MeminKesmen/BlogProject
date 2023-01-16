using BlogProject.Generic;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Utilities;
using BusinessLayer.Concrete;
using BusinessLayer.Utilities;
using BusinessLayer.ViewModels;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace BlogProject.Controllers
{
    [Authorize(Roles = "Writer")]
    public class BlogController : MyController
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;
        private IImageService _imageService;
        public BlogController(IBlogService blogService, ICategoryService categoryService, IImageService imageService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _imageService = imageService;
        }
        [AllowAnonymous]
        public IActionResult Index(int writerId, string search = "", int page = 1)
        {
            IPagedList<Blog> blogs;
            if (writerId == 0)
            {
                blogs = _blogService.GetListWithCategory(b => b.BlogTitle.Contains(search) && b.BlogStatus == true).ToPagedList(page, 20);
            }
            else
            {
                blogs = _blogService.GetListWithCategory(b => b.BlogTitle.Contains(search) && b.WriterId == writerId && b.BlogStatus == true).ToPagedList(page, 20);
            }

            return View(blogs);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            var blog = _blogService.Get(b => b.BlogId == id);
            if (blog == null) { RedirectToAction("Index"); }
            return View(blog);
        }
        public IActionResult BlogListbyWriter()
        {
            var user = GetCurrentUser();
            var blogs = _blogService.GetListWithCategory(b => b.WriterId == user.UserId);
            return View(blogs);
        }
        public IActionResult BlogAdd()
        {
            CategoriesAddViewBag();
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(BlogCreateViewModel blog)
        {
            CategoriesAddViewBag();
            if (!ModelState.IsValid) { return View(); }//validate
            var user = GetCurrentUser();
            var newBlog = new Blog();
            newBlog.WriterId = user.UserId;
            newBlog.BlogTitle = blog.BlogTitle;
            newBlog.BlogContent = blog.BlogContent;
            newBlog.CategoryId = blog.CategoryId;
            if (blog.BlogImage != null)
            {
                newBlog.BlogImage = _imageService.SaveImage(blog.BlogImage, "BlogImages");
            }
            _blogService.Add(newBlog);
            return RedirectToAction("BlogListByWriter", "Blog");

            return View();
        }
        public IActionResult BlogDelete(int id)
        {
            var user = GetCurrentUser();
            var blog = _blogService.Get(b => b.BlogId == id && b.WriterId == user.UserId);
            if (blog == null) { return RedirectToAction("BlogListByWriter"); }
            if (blog.BlogImage != "") { _imageService.DeleteImage(blog.BlogImage); }
            _blogService.Delete(blog);
            return RedirectToAction("BlogListbyWriter");
        }
        public IActionResult BlogActivate(int id)
        {
            var user = GetCurrentUser();
            var blog = _blogService.Get(b => b.BlogId == id && b.WriterId == user.UserId);
            if (blog == null) { RedirectToAction("Index"); }
            blog.BlogStatus = !blog.BlogStatus;
            _blogService.Update(blog);
            return RedirectToAction("BlogListbyWriter");
        }
        public IActionResult BlogEdit(int id)
        {
            var user = GetCurrentUser();
            var blog = _blogService.Get(b => b.BlogId == id && b.WriterId == user.UserId);
            if (blog == null) { RedirectToAction("Index"); }
            var findblog = new BlogCreateViewModel
            {
                BlogId = blog.BlogId,
                BlogTitle = blog.BlogTitle,
                BlogContent = blog.BlogContent
            };
            CategoriesAddViewBag(blog.CategoryId);
            return View(findblog);
        }
        [HttpPost]
        public IActionResult BlogEdit(BlogCreateViewModel blog)
        {
            if (!ModelState.IsValid) { return View(blog); }
            var user = GetCurrentUser();
            var findBlog = _blogService.Get(b => b.BlogId == blog.BlogId && b.WriterId == user.UserId);
            if (findBlog == null) { RedirectToAction("Index"); }
            CategoriesAddViewBag(blog.CategoryId);
            findBlog.BlogTitle = blog.BlogTitle;
            findBlog.BlogContent = blog.BlogContent;
            findBlog.CategoryId = blog.CategoryId;
            if (blog.BlogImage != null)
            {
                _imageService.DeleteImage(findBlog.BlogImage);
                findBlog.BlogImage = _imageService.SaveImage(blog.BlogImage, "BlogImages");
            }
            _blogService.Update(findBlog);
            return RedirectToAction("BlogListbyWriter");
        }
        void CategoriesAddViewBag(int id = 0)
        {
            var categoryList = _categoryService.GetAll(c => c.CategoryStatus == true).Select(c => new SelectListItem { Text = c.CategoryName, Value = c.CategoryId.ToString(), Selected = c.CategoryId == id ? true : false }).ToList();
            ViewBag.Categories = categoryList;
        }
    }
}
