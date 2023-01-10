﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Category
{
    public class CategoryListDashBoard:ViewComponent
    {
        ICategoryService _categoryService;
        public CategoryListDashBoard()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
        }
        public IViewComponentResult Invoke()
        {
            var categoryList = _categoryService.GetAll();
            return View(categoryList);
        }
    }
}
