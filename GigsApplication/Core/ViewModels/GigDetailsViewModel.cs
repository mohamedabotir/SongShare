using GigsApplication.Core.Models;
using System.Collections.Generic;

namespace GigsApplication.Core.ViewModels
{
    public class GigDetailsViewModel
    {
        public Gig gigs { set; get; }
        public bool IsAttending { set; get; }
        public bool IsFollowing { set; get; }
        public bool IsLoved { get; set; }
        public List<Comment> Comments { get; set; }
    }
}