using System.Collections.Generic;
using GigsApplication.Core.Models;

namespace GigsApplication.Core.ViewModels
{
    public class FollowingViewModel
    {
        public FollowingViewModel()
        {
        }

        public IEnumerable<Following> followingArtist { get; set; }
    }
}