using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, BlogDBContext>, IMessageDal
    {
        public List<Message> GetListWithSender(Expression<Func<Message, bool>> filter = null)
        {
            using (var context = new BlogDBContext())
            {
                var query = context.Messages.Include(m => m.SenderWriter);

                var messageList = filter == null ? query.OrderByDescending(m => m.MessageDate).ToList() : query.Where(filter).OrderByDescending(m => m.MessageDate).ToList();
                return messageList;
            }
        }
        public List<Message> GetListWithReceiver(Expression<Func<Message, bool>> filter = null)
        {
            using (var context = new BlogDBContext())
            {
                var query = context.Messages.Include(m => m.ReceiverWriter);

                var messageList = filter == null ? query.OrderByDescending(m => m.MessageDate).ToList() : query.Where(filter).OrderByDescending(m => m.MessageDate).ToList();
                return messageList;
            }
        }
        public Message GetWithSenderAndReceiver(Expression<Func<Message, bool>> filter)
        {
            using (var context = new BlogDBContext())
            {
                var query = context.Messages.Include(m => m.SenderWriter).Include(m => m.ReceiverWriter);

                var message =  query.Where(filter).FirstOrDefault();
                return message;
            }
        }
    }
}
