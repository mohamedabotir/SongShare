using GigsApplication.Core.Models;
using System.Collections.Generic;

namespace GigsApplication.Core.Repositories
{
    public interface IAttendanceRepository
    {
        Attendance GetAttendance(int gigId, string userId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        IEnumerable<Attendance> GetAttendances(string userId);
        void addAttendance(Attendance attendance);
        void deleteAttendance(Attendance attendance);


    }
}