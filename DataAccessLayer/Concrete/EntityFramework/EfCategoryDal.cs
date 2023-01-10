using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, BlogDBContext>, ICategoryDal
    {
        public int Count(Expression<Func<Category, bool>> filter = null)
        {
            using (var context = new BlogDBContext())
            {
                return filter == null ? context.Categories.Count() : context.Categories.Where(filter).Count();
            }
        }
    }
}
