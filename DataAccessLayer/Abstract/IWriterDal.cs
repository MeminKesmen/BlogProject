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
    public interface IWriterDal : IEntityRepository<Writer>
    {
        Writer GetWriterWithRoles(Expression<Func<Writer, bool>> filter);
        List<Writer> GetWriterListWithRoles(Expression<Func<Writer, bool>> filter = null);
    }
}
