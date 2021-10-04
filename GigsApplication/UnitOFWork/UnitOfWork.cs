using GigsApplication.Core;
using GigsApplication.Core.Repositories;
using GigsApplication.UnitOFWork.Repositories;

namespace GigsApplication.UnitOFWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGigRepository _gigRepo { get; private set; }
        public INotificationRepository _notificationRepo { get; private set; }
        public IFollowingRepository _followingRepo { get; private set; }
        public IAttendanceRepository _attendanceRepo { get; }
        public IGenreRepository _genreRepo { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _gigRepo = new GigRepository(context);
            _attendanceRepo = new AttendanceRepository(context);
            _followingRepo = new FollowingRepository(context);
            _genreRepo = new GenreRepository(context);
            _notificationRepo = new NotificationRepository(context);
            _context = context;
        }
        public void complete()
        {
            _context.SaveChanges();
        }
    }
}