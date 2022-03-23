using GigsApplication.Core.Models;
using System.Collections.Generic;

namespace GigsApplication.Core.ViewModels
{
    public class ProfileViewModels
    {
        public string username { get; set; }
        public IEnumerable<Following> Follower { get; set; }
        public IEnumerable<Following> Followee { get; set; }
        public IEnumerable<Gig> Audios { get; set; }
        public int FolloweeCount { get; set; }
        public int FollowerCount { get; set; }
       

    }
}