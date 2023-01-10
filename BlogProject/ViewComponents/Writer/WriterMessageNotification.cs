using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        IMessageService _messageService;
        public WriterMessageNotification()
        {
            _messageService = new MessageManager(new EfMessageDal());
        }
        public IViewComponentResult Invoke()
        {
            var messages=_messageService.GetListWithWriter(m=>m.ReceiverId==1);
            return View(messages);
        }
    }
}
