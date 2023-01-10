using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {

        List<Blog> GetListWithCategory(Expression<Func<Blog, bool>> filter = null, int count = 0);
        List<Blog> GetListByCount(Expression<Func<Blog, bool>> filter = null, int count = 1);
        int Count(Expression<Func<Blog, bool>> filter = null);
    }
}
