using GigsApplication.Core.Models;
using System.Collections.Generic;

namespace GigsApplication.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollower(string followerId, string artistId);
        IEnumerable<Following> GetMyFollowing(string artistId);
        IEnumerable<Following> GetMyFollowers(string artistId);
        void addFollow(Following follower);
        void removeFollow(Following follower);
    }
}