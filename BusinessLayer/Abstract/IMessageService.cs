using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        List<Message> GetListWithSender(Expression<Func<Message, bool>> filter = null);
        List<Message> GetListWithReceiver(Expression<Func<Message, bool>> filter = null);
        Message GetWithSenderAndReceiver(Expression<Func<Message, bool>> filter);
    }
}
