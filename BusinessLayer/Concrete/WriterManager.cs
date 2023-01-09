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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer writer)
        {
            _writerDal.Add(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public Writer Get(Expression<Func<Writer, bool>> filter)
        {
            return _writerDal.Get(filter);
        }

        public List<Writer> GetAll(Expression<Func<Writer, bool>> filter = null)
        {
            return _writerDal.GetAll(filter);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
