using FluentAssertions;
using Gigs.Tests.Extensions;
using GigsApplication.Controllers.Api;
using GigsApplication.Core;
using GigsApplication.Core.Models;
using GigsApplication.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace Gig.Tests.Controller.Api.FollowingsControllerTest
{
    [TestClass]
    public class FollowingsControllerTest
    {
        FollowingsController following;
        Mock<IFollowingRepository> followingMock;

        [TestInitialize]
        public void TestInitialize()
        {
            followingMock = new Mock<IFollowingRepository>();
            var unofWork = new Mock<IUnitOfWork>();
            unofWork.SetupGet(e => e._followingRepo).Returns(followingMock.Object);
            following = new FollowingsController(unofWork.Object);
            following.MockCurrentUser("3", "mohamed");
        }
        [TestMethod]
        public void follow_isExisting_badRequest()
        {
            var followings = new Following();
            followingMock.Setup(e => e.GetFollower("3", "4")).Returns(followings);
            var result = following.Follow(new GigsApplication.Core.Dtos.FollowingDto
            {
                FolloweeId = "4"
            });
            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }
        [TestMethod]
        public void follow_successfullFollow_Ok()
        {
            var followings = new Following();
            followingMock.Setup(e => e.GetFollower("3", "3")).Returns(followings);
            var result = following.Follow(new GigsApplication.Core.Dtos.FollowingDto
            {
                FolloweeId = "1"
            });
            result.Should().BeOfType<OkResult>();
        }
        [TestMethod]
        public void follow_followIsFollowee_BadRequest()
        {
            var followings = new Following();
            followingMock.Setup(e => e.GetFollower("3", "3")).Returns(followings);
            var result = following.Follow(new GigsApplication.Core.Dtos.FollowingDto
            {
                FolloweeId = "3"
            });
            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }
        [TestMethod]
        public void unfollow_isFollowing_badRequest()
        {
            var followings = new Following();
            followingMock.Setup(e => e.GetFollower("3", "3")).Returns(followings);
            var result = following.unFollow("1");
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
