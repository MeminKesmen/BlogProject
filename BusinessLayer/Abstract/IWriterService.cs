using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetAll(Expression<Func<Writer, bool>> filter = null);
        Writer Get(Expression<Func<Writer, bool>> filter);
        void Add(Writer writer);
        void Update(Writer writer);
        void Delete(Writer writer);
    }
}
