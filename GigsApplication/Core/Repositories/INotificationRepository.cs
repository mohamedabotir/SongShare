using GigsApplication.Core.Models;
using System.Collections.Generic;

namespace GigsApplication.Core.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetMyNotifications(string userId);
        IEnumerable<UserNotification> GetUnReadNotification(string userId);
    }
}