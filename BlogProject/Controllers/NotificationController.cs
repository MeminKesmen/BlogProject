using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class NotificationController : Controller
    {
        private INotificationService _notificationService;
        public NotificationController()
        {
            _notificationService = new NotificationManager(new EfNotificationDal());
            
        }
        public IActionResult AllNotification()
        {
            var notifications = _notificationService.GetAll();
            return View(notifications);
        }
    }
}
