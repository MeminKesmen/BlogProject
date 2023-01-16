using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var id = userId == null ? 1 : int.Parse(userId);
            var messages=_messageService.GetListWithSender(m=>m.ReceiverId==id&&m.MessageStatus==false);
            return View(messages);
        }
    }
}
