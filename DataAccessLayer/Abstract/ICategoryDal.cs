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
    public interface ICategoryDal : IEntityRepository<Category>
    {
        int Count(Expression<Func<Category, bool>> filter = null);
    }
}
