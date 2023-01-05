﻿using BusinessLayer.Abstract;
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
            return filter == null ? _blogDal.GetAll() : _blogDal.GetAll(filter);
        }

        public List<Blog> GetListWithCategory(Expression<Func<Blog, bool>> filter = null)
        {
           return _blogDal.GetListWithCategory(filter);
        }

        public void Update(Blog blog)
        {
            _blogDal.Update(blog);
        }
    }
}
