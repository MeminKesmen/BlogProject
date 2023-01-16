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
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public void Add(Message entity)
        {
            _messageDal.Add(entity);
        }

        public int Count(Expression<Func<Message, bool>> filter = null)
        {
            return _messageDal.Count(filter);
        }

        public void Delete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public Message Get(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.Get(filter);
        }

        public List<Message> GetAll(Expression<Func<Message, bool>> filter = null)
        {
            return _messageDal.GetAll(filter);
        }

        public List<Message> GetListWithReceiver(Expression<Func<Message, bool>> filter = null)
        {
            return _messageDal.GetListWithReceiver(filter);
        }

        public List<Message> GetListWithSender(Expression<Func<Message, bool>> filter = null)
        {
            return _messageDal.GetListWithSender(filter);
        }

        public Message GetWithSenderAndReceiver(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.GetWithSenderAndReceiver(filter);
        }

        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
