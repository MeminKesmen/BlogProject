using BusinessLayer.Abstract;
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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog blog)
        {
            _blogDal.Add(blog);
        }

        public int Count(Expression<Func<Blog, bool>> filter = null)
        {
            return _blogDal.Count(filter);
        }

        public void Delete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public Blog Get(Expression<Func<Blog, bool>> filter)
        {
            return _blogDal.Get(filter);
        }

        public List<Blog> GetAll(Expression<Func<Blog, bool>> filter = null)
        {
            return  _blogDal.GetAll(filter);
        }

        public List<Blog> GetListByCount(Expression<Func<Blog, bool>> filter = null, int count = 1)
        {
            return _blogDal.GetListByCount(filter,count);
        }

        public List<Blog> GetListWithCategory(Expression<Func<Blog, bool>> filter = null, int count = 0)
        {
           return _blogDal.GetListWithCategory(filter,count);
        }

        public void Update(Blog blog)
        {
            _blogDal.Update(blog);
        }
    }
}
