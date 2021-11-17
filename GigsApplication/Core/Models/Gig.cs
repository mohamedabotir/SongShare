using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace GigsApplication.Core.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public ApplicationUser Artist { get; set; }
        public bool IsCanceled { get; private set; }
        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }

        public string Song { get; set; }

        public Genre Genre { get; set; }

        public int GenreID { set; get; }
        public ICollection<Love> loves { get; private set; }
        public ICollection<Attendance> Attendences { get; private set; }
        public ICollection<Comment> Comments { get; set; }
        public Gig()
        {
            Attendences = new Collection<Attendance>();
            loves = new Collection<Love>();
            Comments = new Collection<Comment>();
        }
       
        public byte[] SongData { set; get; }
       
        public string SongMimeType { set; get; }
        public void Cancel()
        {
            this.IsCanceled = true;
            var notification = Notification.CancelNotification(this);


            foreach (var attendee in this.Attendences.Select(s => s.Attendee))
            {
                attendee.Notify(notification);

            }
        }


        public void Update(string song, DateTime dateTime, int genre,byte[]audioData,string audioType)
        {
            var notification = Notification.UpdateNotification(this, DateTime, Song);

            Song = song;
            GenreID = genre;
            DateTime = dateTime;
            SongData = audioData;
            SongMimeType = audioType;
               
            foreach (var attendee in this.Attendences.Select(e => e.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}