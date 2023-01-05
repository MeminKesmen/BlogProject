using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetAll(Expression<Func<About, bool>> filter = null);
        About Get(Expression<Func<About, bool>> filter);
        void Add(About about);
        void Update(About about);
        void Delete(About about);
    }
}
