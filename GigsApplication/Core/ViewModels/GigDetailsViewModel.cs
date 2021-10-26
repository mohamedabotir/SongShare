using GigsApplication.Core.Models;

namespace GigsApplication.Core.ViewModels
{
    public class GigDetailsViewModel
    {
        public Gig gigs { set; get; }
        public bool IsAttending { set; get; }
        public bool IsFollowing { set; get; }
        public bool IsLoved { get; set; }
    }
}