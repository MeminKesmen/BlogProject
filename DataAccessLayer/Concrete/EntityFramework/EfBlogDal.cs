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
        public List<Blog> GetListWithCategory(Expression<Func<Blog, bool>> filter = null, int count = 0)
        {
            using (var context = new BlogDBContext())
            {
                var query = context.Blogs.Include(b => b.Category);
                List<Blog> blogList;
                if (filter == null)
                {
                    blogList = count == 0 ? blogList = query.OrderByDescending(b => b.BlogCreateDate).ToList() : blogList = query.OrderByDescending(b => b.BlogCreateDate).Take(count).ToList();
                }
                else
                {
                    blogList = count == 0 ? blogList = query.Where(filter).OrderByDescending(b => b.BlogCreateDate).ToList() : blogList = query.Where(filter).OrderByDescending(b => b.BlogCreateDate).Take(count).ToList();

                }

                return blogList;
            }
        }

        public List<Blog> GetListByCount(Expression<Func<Blog, bool>> filter = null, int count = 1)
        {
            using (var context = new BlogDBContext())
            {
                var blogList = filter == null ? context.Blogs.OrderByDescending(b => b.BlogCreateDate).Take(count).ToList() : context.Blogs.Where(filter).OrderByDescending(b => b.BlogCreateDate).Take(count).ToList();
                return blogList;
            }
        }

    }
}
