using FluentAssertions;
using Gigs.Tests.Extensions;
using GigsApplication.Controllers.Api;
using GigsApplication.Core;
using GigsApplication.Core.Models;
using GigsApplication.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace Gig.Tests.Controller.Api.AttendanceController
{
    [TestClass]
    public class AttendanceControllerTest
    {
        private AttendancesController attendanceController;
        Mock<IAttendanceRepository> attendanceRepo;
        Mock<IGigRepository> gig;
        [TestInitialize]
        public void TestInitialize()
        {
            attendanceRepo = new Mock<IAttendanceRepository>();
            gig = new Mock<IGigRepository>();
            var unWork = new Mock<IUnitOfWork>();
            unWork.SetupGet(r => r._gigRepo).Returns(gig.Object);
            unWork.SetupGet(r => r._attendanceRepo).Returns(attendanceRepo.Object);
            attendanceController = new AttendancesController(unWork.Object);
            attendanceController.MockCurrentUser("2", "ali");
        }
        [TestMethod]
        public void attend_AlreadyAttended_BadRequest()
        {
            Attendance attendance = new Attendance();

            attendanceRepo.Setup(e => e.GetAttendance(1, "2")).Returns(attendance);

            var result = attendanceController.Attend(new GigsApplication.Core.Dtos.AttendanceDto
            {
                GigId = 1
            });

            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }
        [TestMethod]
        public void attend_isExistingGig_NotFound()
        {
            var gigs = new GigsApplication.Core.Models.Gig();
            gig.Setup(e => e.GetGig(3)).Returns(gigs);
            var result = attendanceController.Attend(new GigsApplication.Core.Dtos.AttendanceDto
            {
                GigId = 1
            });


            result.Should().BeOfType<NotFoundResult>();
        }
        [TestMethod]
        public void attend_deleteAttendance_notfound()
        {
            Attendance attendance = new Attendance();

            attendanceRepo.Setup(e => e.GetAttendance(1, "2")).Returns(attendance);
            var result = attendanceController.DeleteAttendance(2);
            result.Should().BeOfType<NotFoundResult>();
        }
        [TestMethod]
        public void attend_deleteAttendance_Ok()
        {
            Attendance attendance = new Attendance();

            attendanceRepo.Setup(e => e.GetAttendance(1, "2")).Returns(attendance);
            var result = attendanceController.DeleteAttendance(1);
            result.Should().BeOfType<OkResult>();
        }

    }
}
