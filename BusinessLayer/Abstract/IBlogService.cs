using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetAll(Expression<Func<Blog, bool>> filter = null);
        Blog Get(Expression<Func<Blog, bool>> filter);
        void Add(Blog blog);
        void Update(Blog blog);
        void Delete(Blog blog);
    }
}
