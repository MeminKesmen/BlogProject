using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal :IEntityRepository<Blog>
    {
        List<Blog> GetListWithCategory(Expression<Func<Blog, bool>> filter = null);
        public List<Blog> GetListByCount(Expression<Func<Blog, bool>> filter = null, int count = 1);
    }
}
