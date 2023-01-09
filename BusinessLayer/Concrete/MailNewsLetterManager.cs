using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
