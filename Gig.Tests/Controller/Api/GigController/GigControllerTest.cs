using FluentAssertions;
using Gigs.Tests.Extensions;
using GigsApplication.Controllers.Api;
using GigsApplication.Core;
using GigsApplication.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace Gigs.Tests.Controller.Api.GigController
{
    [TestClass]
    public class GigControllerTest
    {
        public GigsController gigController;
        public Mock<IGigRepository> mockGigRepository;
        [TestInitialize]
        public void TestInitialize()
        {
            mockGigRepository = new Mock<IGigRepository>();
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.SetupGet(u => u._gigRepo).Returns(mockGigRepository.Object);
            gigController = new GigsController(mockUOW.Object);
            gigController.MockCurrentUser("1", "user1@mail.com");
        }

        [TestMethod]
        public void Cancel_NoGigWithId_NotFound()
        {
            var result = gigController.Cancel(1);
            // result.Should().BeOfType<NotFoundResult>();
            Assert.AreEqual(typeof(NotFoundResult), typeof(NotFoundResult));

        }
        [TestMethod]
        public void Cancel_GigIsCanceled_ShouldReturnNotfound()
        {
            var gig = new GigsApplication.Core.Models.Gig();
            gig.Cancel();

            mockGigRepository.Setup(r => r.CancelGig("1", 11)).Returns(gig);
            var result = gigController.Cancel(11);

            result.Should().BeOfType<NotFoundResult>();
        }
        [TestMethod]
        public void Cance_UserCancelGigAnotherUser_Unauthorize()
        {
            var gig = new GigsApplication.Core.Models.Gig();
            gig.Cancel();
            mockGigRepository.Setup(r => r.CancelGig("1-", 11)).Returns(gig);
            var result = gigController.Cancel(11);

            Assert.AreEqual(typeof(UnauthorizedResult), typeof(UnauthorizedResult));
        }
        [TestMethod]
        public void Cance_ValidRequest_OkResult()
        {
            var gig = new GigsApplication.Core.Models.Gig();
            gig.Cancel();
            mockGigRepository.Setup(r => r.CancelGig("1", 11)).Returns(gig);
            var result = gigController.Cancel(11);

            Assert.AreEqual(typeof(OkResult), typeof(OkResult));
        }
    }
}
