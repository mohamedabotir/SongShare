using GigsApplication.Core.Models;
using GigsApplication.UnitOFWork.EntityConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GigsApplication.UnitOFWork
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>,IApplicationDbContext
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Love> Loves { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new GigConfiguration());

            modelBuilder.Configurations.Add(new UserConfiguration());

            modelBuilder.Configurations.Add(new GenreConfiguration());

            modelBuilder.Configurations.Add(new UserNotificationConfiguration());

            modelBuilder.Configurations.Add(new FollowingConfiguration());

            modelBuilder.Configurations.Add(new AttendanceConfiguration());
            modelBuilder.Configurations.Add(new LoveConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}