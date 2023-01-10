using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class MessageController : Controller
    {
        private IMessageService _messageService;
        public MessageController()
        {
            _messageService = new MessageManager(new EfMessageDal());
        }
        public IActionResult InBox()
        {
            var messages = _messageService.GetListWithWriter(m => m.ReceiverId == 1);
            return View();
        }
        public IActionResult MessageDetails(int id)
        {
            var message = _messageService.Get(m=>m.MessageId==id);
            return View(message);
        }
    }
}
