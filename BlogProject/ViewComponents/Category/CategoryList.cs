using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Category
{
    public class CategoryList:ViewComponent
    {
        ICategoryService _categoryService;
        public CategoryList()
        {
            _categoryService = new CategoryManager(new EfCategoryDal(), new EfBlogDal());
        }
        public IViewComponentResult Invoke()
        {
            var categoryList = _categoryService.GetListWithBlogCount();
            return View(categoryList);
        }

    }
}
