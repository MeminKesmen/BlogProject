using BusinessLayer.Abstract;
using BusinessLayer.ViewModels;
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
        IBlogDal _blogDal;

        public WriterManager(IWriterDal writerDal, IBlogDal blogDal)
        {
            _writerDal = writerDal;
            _blogDal = blogDal;
        }

        public void Add(Writer writer)
        {
            _writerDal.Add(writer);
        }

        public int Count(Expression<Func<Writer, bool>> filter = null)
        {
            return _writerDal.Count(filter);
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

        public List<WriterListWithBlogCount> GetAllWriterWithBlogCount()
        {
            List<WriterListWithBlogCount> writerList = new List<WriterListWithBlogCount>();
            var writers = GetAll();
            foreach (var item in writers)
            {
                writerList.Add(new WriterListWithBlogCount
                {
                    WriterId = item.WriterId,
                    WriterName = item.WriterName,
                    WriterImage = item.WriterImage,
                    BlogCount = _blogDal.Count(b => b.WriterId == item.WriterId)
                });
            }
            return writerList;
        }

        public List<Writer> GetWriterListWithRoles(Expression<Func<Writer, bool>> filter = null)
        {
            return _writerDal.GetWriterListWithRoles(filter);
        }

        public Writer GetWriterWithRoles(Expression<Func<Writer, bool>> filter)
        {
            return _writerDal.GetWriterWithRoles(filter);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
