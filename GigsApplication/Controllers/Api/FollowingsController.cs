using GigsApplication.Core;
using GigsApplication.Core.Dtos;
using GigsApplication.Core.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigsApplication.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private IUnitOfWork unitOfWork;
        public FollowingsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            var getFollower = unitOfWork._followingRepo.GetFollower(userId, dto.FolloweeId) != null;
            //_context.Followings.Any(e => e.FolloweeId == dto.FolloweeId && e.FollowerId == userId
            if (getFollower || dto.FolloweeId == userId)
            {
                return BadRequest("Following already exists.");
            }
            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            unitOfWork._followingRepo.addFollow(following);
            unitOfWork.complete();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult unFollow(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = unitOfWork._followingRepo.GetFollower(userId, id);
            if (following == null)
                return NotFound();
            unitOfWork._followingRepo.removeFollow(following);
            unitOfWork.complete();
            return Ok(id);
        }
    }
}
