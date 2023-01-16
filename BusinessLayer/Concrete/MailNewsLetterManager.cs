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
    public class MailNewsLetterManager : IMailNewsLetterService
    {
        private IMailNewsLetterDal _mailNewsLetterDal;
        public MailNewsLetterManager(IMailNewsLetterDal mailNewsLetterDal)
        {
            _mailNewsLetterDal = mailNewsLetterDal;
        }
        public void Add(MailNewsLetter mailNewsLetter)
        {
            _mailNewsLetterDal.Add(mailNewsLetter);
        }

        public int Count(Expression<Func<MailNewsLetter, bool>> filter = null)
        {
            return _mailNewsLetterDal.Count(filter);
        }

        public void Delete(MailNewsLetter entity)
        {
            _mailNewsLetterDal.Delete(entity);
        }

        public MailNewsLetter Get(Expression<Func<MailNewsLetter, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<MailNewsLetter> GetAll(Expression<Func<MailNewsLetter, bool>> filter = null)
        {
            return _mailNewsLetterDal.GetAll(filter);
        }

        public void Update(MailNewsLetter entity)
        {
            throw new NotImplementedException();
        }
    }
}
