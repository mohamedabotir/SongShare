using GigsApplication.Core.Models;
using GigsApplication.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigsApplication.UnitOFWork.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetMyNotifications(string userId)
        {
            return
                _context.UserNotifications.
                    Where(e => e.UserId == userId).
                    Select(un => un.Notification).OrderBy(f => f.DateTime).
                    Include(u => u.Gig.Artist).ToList();
        }

        public IEnumerable<UserNotification> GetUnReadNotification(string userId)
        {
            return
            _context.UserNotifications.Where(e => e.UserId == userId && !e.IsRead).ToList();
        }
    }
}