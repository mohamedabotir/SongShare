using GigsApplication.Core.Models;
using GigsApplication.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigsApplication.UnitOFWork.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private ApplicationDbContext _context;
        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Following GetFollower(string followerId, string artistId)
        {
            return
                _context.Followings.
                    SingleOrDefault(e => e.FollowerId == followerId && e.FolloweeId == artistId);

        }
        public IEnumerable<Following> GetMyFollowing(string artistId)
        {
            return
                 _context.Followings.
                Include(e => e.Followee).
               
                Where(e => e.FollowerId == artistId);
        }
        public IEnumerable<Following> GetMyFollowers(string artistId)
        {
            return
                _context.Followings.
               
               Include(e => e.Follower).
               Where(e => e.FolloweeId == artistId);
        }
        public void addFollow(Following follower)
        {

            _context.Followings.Add(follower);
        }

        public void removeFollow(Following follower)
        {
            _context.Followings.Remove(follower);
        }


    }
}