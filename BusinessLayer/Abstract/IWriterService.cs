using BusinessLayer.ViewModels;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService: IGenericService<Writer>
    {
        Writer GetWriterWithRoles(Expression<Func<Writer, bool>> filter);
        List<Writer> GetWriterListWithRoles(Expression<Func<Writer, bool>> filter = null);
        List<WriterListWithBlogCount> GetAllWriterWithBlogCount();
    }
}
