using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Writer")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryManager(new EfCategoryDal(),new EfBlogDal());
        }
       
        public IActionResult Index(int page = 1)
        {
            
            var categoryList = _categoryService.GetAll().ToPagedList(page, 10);
            return View(categoryList);
        }
        
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            if (!ModelState.IsValid) { return View(); }
            _categoryService.Add(category);
            return View();
        }
        public IActionResult CategoryActivate(int id)
        {
            var category = _categoryService.Get(c => c.CategoryId == id);
            if (category == null) { RedirectToAction("Index"); }//bulunamadı
            category.CategoryStatus = !category.CategoryStatus;
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryEdit(int id)
        {
            var category = _categoryService.Get(c=>c.CategoryId==id);
            if (category == null) { RedirectToAction("Index"); }//bulunamadı
            return View(category);
        }
        [HttpPost]
        public IActionResult CategoryEdit(Category category)
        {
            if (!ModelState.IsValid) { return View(); } 
            var findCategory = _categoryService.Get(c=>c.CategoryId==category.CategoryId);
            if (findCategory == null) { RedirectToAction("Index"); }//bulunamadı
            findCategory.CategoryName = category.CategoryName;
            findCategory.CategoryDescription = category.CategoryDescription;
            _categoryService.Update(findCategory);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryDelete(int id)
        {
            var category = _categoryService.Get(c=>c.CategoryId==id);
            if (category!=null) { _categoryService.Delete(category); }
            return RedirectToAction("Index");
        }
    }
}
