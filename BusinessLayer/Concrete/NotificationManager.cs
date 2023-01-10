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
    public class NotificationManager : INotificationService
    {
        private INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Add(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void Delete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public Notification Get(Expression<Func<Notification, bool>> filter)
        {
            return _notificationDal.Get(filter);
        }

        public List<Notification> GetAll(Expression<Func<Notification, bool>> filter = null)
        {
            return _notificationDal.GetAll(filter);
        }

        public void Update(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
