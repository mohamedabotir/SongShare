using GigsApplication.Core.Repositories;

namespace GigsApplication.Core
{
    public interface IUnitOfWork
    {
        IAttendanceRepository _attendanceRepo { get; }
        IFollowingRepository _followingRepo { get; }
        IGenreRepository _genreRepo { get; }
        IGigRepository _gigRepo { get; }
        INotificationRepository _notificationRepo { get; }
        ILove _loveRepo { get; }
        void complete();
    }
}