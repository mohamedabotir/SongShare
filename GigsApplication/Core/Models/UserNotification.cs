using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigsApplication.Core.Models
{
    public class UserNotification
    {
        private ApplicationUser applicationUser;
        protected UserNotification()
        {

        }
        public UserNotification(ApplicationUser applicationUser, Notification notification)
        {
            if (applicationUser == null)
                throw new ArgumentNullException("user null");
            if (notification == null)
                throw new ArgumentNullException("notification null");
            this.applicationUser = applicationUser;
            Notification = notification;
        }

        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }

        public ApplicationUser User { get; private set; }

        public Notification Notification { get; private set; }
        public bool IsRead { get; private set; }

        public void Read()
        {
            IsRead = true;
        }
    }
}