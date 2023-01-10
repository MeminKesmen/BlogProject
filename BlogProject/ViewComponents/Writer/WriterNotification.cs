using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterNotification: ViewComponent
    {
        private INotificationService _notificationService;
        public WriterNotification()
        {
            _notificationService = new NotificationManager(new EfNotificationDal());
        }
        public IViewComponentResult Invoke()
        {
            var notifications = _notificationService.GetAll();
            return View(notifications);
        }
    }
}
