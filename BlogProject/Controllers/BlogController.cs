using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        IBlogService _blogService;
        ICategoryService _categoryService;
        public BlogController()
        {
            _blogService = new BlogManager(new EfBlogDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
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
        public IActionResult BlogListbyWriter()
        {
            var blogs=_blogService.GetListWithCategory(b=>b.WriterId==1);
            return View(blogs);
        }
        public IActionResult BlogAdd()
        {
            var categoryList = _categoryService.GetAll().Select(c => new SelectListItem { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList();
            ViewBag.Categories = categoryList;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult result = blogValidator.Validate(blog);
            if (result.IsValid) 
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Now;
                blog.WriterId = 1;
                _blogService.Add(blog);
                return RedirectToAction("BlogListByWriter","Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult BlogDelete(int id) 
        {
            var blog = _blogService.Get(b=>b.BlogId==id);//yazar kontrolü ve null kontrolü
            _blogService.Delete(blog);
            return RedirectToAction("BlogListbyWriter");
        }
        public IActionResult BlogEdit(int id)
        {
            var blog = _blogService.Get(b=>b.BlogId==id);//yazar kontrolü ve null kontrolü
            var categoryList = _categoryService.GetAll().Select(c => new SelectListItem { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList();
            ViewBag.Categories = categoryList;
            return View(blog);
        }
        [HttpPost]
        public IActionResult BlogEdit(Blog blog)
        {
            var findBlog = _blogService.Get(b=>b.BlogId==blog.BlogId);//yazar kontrolü ve null kontrolü
            findBlog.BlogTitle = blog.BlogTitle;
            findBlog.BlogContent = blog.BlogContent;
            findBlog.BlogImage = blog.BlogImage;
            findBlog.BlogThumbnailImage = blog.BlogThumbnailImage;
            findBlog.CategoryId = blog.CategoryId;
            _blogService.Update(findBlog);
            return RedirectToAction("BlogListbyWriter");
        }
    }
}
