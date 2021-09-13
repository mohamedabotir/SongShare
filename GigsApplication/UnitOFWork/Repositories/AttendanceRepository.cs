using GigsApplication.Core.Models;
using GigsApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GigsApplication.UnitOFWork.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Attendance GetAttendance(int gigId, string userId)
        {
            return
                 _context.Attendances.
                    SingleOrDefault(e => e.GigId == gigId && e.AttendeeId == userId);
        }
        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances.
                          Where(e => e.AttendeeId == userId && e.Gig.DateTime > DateTime.Now).ToList();
        }

        public void addAttendance(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void deleteAttendance(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }
    }
}