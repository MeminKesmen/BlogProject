using BlogProject.Generic;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ViewModels;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    [Authorize(Roles = "Writer")]
    public class MessageController : MyController
    {
        private IMessageService _messageService;
        private IWriterService _writerService;
        public MessageController(IMessageService messageService, IWriterService writerService)
        {
            _messageService = messageService;
            _writerService = writerService;
        }
        public IActionResult InBox()
        {
            var user = GetCurrentUser();
            var messageList = _messageService.GetListWithSender(m => m.ReceiverId == user.UserId);
            return View(messageList);
        }
        public IActionResult SendBox()
        {
            var user = GetCurrentUser();
            var messageList = _messageService.GetListWithReceiver(m => m.SenderId == user.UserId);
            return View(messageList);
        }
        public IActionResult MessageDetails(int id)
        {
            var message = _messageService.GetWithSenderAndReceiver(m => m.MessageId == id);
            if (message == null) { return RedirectToAction("InBox"); }
            var user = GetCurrentUser();
            if (message.SenderId != user.UserId)
            {
                message.MessageStatus = true;
                _messageService.Update(message);
            }

            return View(message);
        }
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(MessageRequest message)
        {
            if (!ModelState.IsValid) { return View(); }
            var receiver = _writerService.Get(w => w.WriterMail.Equals(message.ReceiverMail));
            var user = GetCurrentUser();
            if (receiver == null || receiver.WriterId == user.UserId) { return View(); }//kullanıcı bulunamadı

            _messageService.Add(new Message
            {
                SenderId = user.UserId,
                ReceiverId = receiver.WriterId,
                Subject = message.Subject,
                MessageDetails = message.MessageDetails
            });
            return RedirectToAction("Inbox");
        }
        public IActionResult DeleteMessage(int id)
        {
            var user = GetCurrentUser();
            var message = _messageService.Get(m => m.MessageId == id && m.ReceiverId == user.UserId);
            if (message == null) { return RedirectToAction("Inbox"); }
            _messageService.Delete(message);
            return RedirectToAction("InBox");
        }
    }
}
