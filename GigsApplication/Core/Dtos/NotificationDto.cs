using System;
using GigsApplication.Core.Models;

namespace GigsApplication.Core.Dtos
{
    public class NotificationDto
    {
        public int id { get; set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }
        public static int Notificationlength { set; get; }
        public GigDto Gig { private set; get; }
    }






}