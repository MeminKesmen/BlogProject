using BusinessLayer.Abstract;
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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About about)
        {
            _aboutDal.Add(about);
        }

        public void Delete(About about)
        {
            _aboutDal.Delete(about);
        }

        public About Get(Expression<Func<About, bool>> filter)
        {
            return _aboutDal.Get(filter);
        }

        public List<About> GetAll(Expression<Func<About, bool>> filter = null)
        {
            return filter == null ? _aboutDal.GetAll() : _aboutDal.GetAll(filter);
        }

        public void Update(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
