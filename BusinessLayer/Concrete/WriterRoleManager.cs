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
    public class WriterRoleManager : IWriterRoleService
    {
        private IWriterRoleDal _writerRoleDal;
        public WriterRoleManager(IWriterRoleDal writerRoleDal)
        {
            _writerRoleDal = writerRoleDal;
        }

        public void Add(WriterRole entity)
        {
            _writerRoleDal.Add(entity);
        }

        public int Count(Expression<Func<WriterRole, bool>> filter = null)
        {
            return _writerRoleDal.Count(filter);
        }

        public void Delete(WriterRole entity)
        {
            _writerRoleDal.Delete(entity);
        }

        public WriterRole Get(Expression<Func<WriterRole, bool>> filter)
        {
            return _writerRoleDal.Get(filter);
        }

        public List<WriterRole> GetAll(Expression<Func<WriterRole, bool>> filter = null)
        {
            return _writerRoleDal.GetAll(filter);
        }

        public void Update(WriterRole entity)
        {
            _writerRoleDal.Update(entity);
        }
    }
}
