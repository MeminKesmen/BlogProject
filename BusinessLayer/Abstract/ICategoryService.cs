using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll(Expression<Func<Category, bool>> filter = null);
        Category Get(Expression<Func<Category, bool>> filter);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
