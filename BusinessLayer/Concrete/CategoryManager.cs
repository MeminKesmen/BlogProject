using BusinessLayer.Abstract;
using BusinessLayer.ViewModels;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        IBlogDal _blogDal;
        public CategoryManager(ICategoryDal categoryDal, IBlogDal blogDal)
        {
            _categoryDal = categoryDal;
            _blogDal = blogDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public int Count(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.Count(filter);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.Get(filter);
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetAll(filter);
        }

        public List<CategoryWithBlogCount> GetListWithBlogCount()
        {
            var categories = GetAll();
            List<CategoryWithBlogCount> categoriList = new List<CategoryWithBlogCount>();
            foreach (var item in categories)
            {
                categoriList.Add(new CategoryWithBlogCount
                {
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName,
                    BlogCount = _blogDal.Count(b => b.CategoryId == item.CategoryId)
                }); ;
            }
            return categoriList;
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
        
    }
}
