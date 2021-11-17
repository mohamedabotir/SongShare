using GigsApplication.Core.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace GigsApplication.UnitOFWork
{
    public interface IApplicationDbContext
    {
         DbSet<Gig> Gigs { get; set; }
         DbSet<Genre> Genres { get; set; }
         DbSet<Attendance> Attendances { get; set; }
         DbSet<Following> Followings { get; set; }
         DbSet<UserNotification> UserNotifications { get; set; }
         DbSet<Notification> Notifications { get; set; }
         DbSet<Comment> Comments { get; set; }
         IDbSet<ApplicationUser> Users { get; set; }
    }
}