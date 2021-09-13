using System.ComponentModel.DataAnnotations;

namespace GigsApplication.Core.Models
{
    public class Attendance
    {
        public Gig Gig { get; set; }
        public ApplicationUser Attendee { get; set; }
        [Key]

        public int GigId { get; set; }
        [Key]

        public string AttendeeId { get; set; }

    }
}