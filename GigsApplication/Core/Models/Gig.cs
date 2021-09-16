using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GigsApplication.Core.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public ApplicationUser Artist { get; set; }
        public bool IsCanceled { get; private set; }
        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }


        public string Venue { get; set; }

        public Genre Genre { get; set; }

        public int GenreID { set; get; }
        public ICollection<Attendance> Attendences { get; private set; }
        public Gig()
        {
            Attendences = new Collection<Attendance>();
        }

        public void Cancel()
        {
            this.IsCanceled = true;
            var notification = Notification.CancelNotification(this);


            foreach (var attendee in this.Attendences.Select(s => s.Attendee))
            {
                attendee.Notify(notification);

            }
        }


        public void Update(string venue, DateTime dateTime, int genre)
        {
            var notification = Notification.UpdateNotification(this, DateTime, venue);

            Venue = venue;
            GenreID = genre;
            DateTime = dateTime;
            foreach (var attendee in this.Attendences.Select(e => e.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}