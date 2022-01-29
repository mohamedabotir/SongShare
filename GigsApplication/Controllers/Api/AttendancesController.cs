using GigsApplication.Core;
using GigsApplication.Core.Dtos;
using GigsApplication.Core.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigsApplication.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private IUnitOfWork unitOfWork;
        public AttendancesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [Authorize]
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            var gig = unitOfWork._gigRepo.GetGig(dto.GigId);
            if (unitOfWork._attendanceRepo.GetAttendance(dto.GigId, userId) != null)
            {
                return BadRequest("The Attendance already exists.");
            }
            if (gig == null)
                return NotFound();
            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            unitOfWork._attendanceRepo.addAttendance(attendance);
            unitOfWork.complete();
            return Ok();
        }
        [Authorize]
        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userId = User.Identity.GetUserId();
            var attendances = unitOfWork._attendanceRepo.GetAttendance(id, userId);
            if (attendances == null)
                return NotFound();
            unitOfWork._attendanceRepo.deleteAttendance(attendances);
            unitOfWork.complete();
            return Ok();

        }
    }
}
