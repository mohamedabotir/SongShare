using System;
using System.ComponentModel.DataAnnotations;

namespace GigsApplication.Core.Models
{
    public class Notification
    {

        public Notification()
        {

        }


        public int id { get; set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Gig Gig { private set; get; }


        protected Notification(NotificationType notificationType, Gig gig)
        {
            if (gig == null)
                throw new ArgumentNullException("gig null");
            this.Type = notificationType;
            Gig = gig;
            DateTime = DateTime.Now;
        }
        public static Notification CancelNotification(Gig gig)
        {
            return new Notification(NotificationType.GigCanceled, gig);
        }



        public static Notification UpdateNotification(Gig gig, DateTime OriginalDateTime, string OriginalVenue)
        {
            var notification = new Notification(NotificationType.GigUpdated, gig);
            notification.OriginalVenue = OriginalVenue;
            notification.OriginalDateTime = OriginalDateTime;
            return notification;

        }
        public static Notification CreateNotification(Gig gig)
        {
            return new Notification(NotificationType.GigCreated, gig);
        }

    }
}