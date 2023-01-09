using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, BlogDBContext>, IBlogDal
    {
        public List<Blog> GetListWithCategory(Expression<Func<Blog, bool>> filter = null)
        {
            using (var context = new BlogDBContext())
            {
                var blogList = filter == null ? context.Blogs.Include(b => b.Category).ToList() : context.Blogs.Include(b => b.Category).Where(filter).ToList();
                return blogList;
            }
        }

        public List<Blog> GetListByCount(Expression<Func<Blog, bool>> filter = null, int count = 1)
        {
            using (var context = new BlogDBContext())
            {
                var blogList = filter == null ? context.Blogs.OrderBy(b => b.BlogCreateDate).Take(count).ToList() : context.Blogs.Where(filter).OrderBy(b => b.BlogCreateDate).Take(count).ToList();
                return blogList;
            }
        }
    }
}
