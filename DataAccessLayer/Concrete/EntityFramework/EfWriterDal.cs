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
    public class EfWriterDal : EfEntityRepositoryBase<Writer, BlogDBContext>, IWriterDal
    {
        public Writer GetWriterWithRoles(Expression<Func<Writer, bool>> filter)
        {
            using (var context = new BlogDBContext())
            {
                var writer = context.Writers.Include(w => w.WriterRoles).ThenInclude(w => w.Role).Where(filter).FirstOrDefault();
                return writer;
            }
        }
        public List<Writer> GetWriterListWithRoles(Expression<Func<Writer, bool>> filter = null)
        {
            using (var context = new BlogDBContext())
            {
                var writer = filter == null ? context.Writers.Include(w => w.WriterRoles).ThenInclude(w => w.Role).ToList() : context.Writers.Include(w => w.WriterRoles).ThenInclude(w => w.Role).Where(filter).ToList();
                return writer;
            }
        }
    }
}
