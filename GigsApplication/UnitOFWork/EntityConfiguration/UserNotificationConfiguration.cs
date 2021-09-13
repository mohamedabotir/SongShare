using GigsApplication.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigsApplication.UnitOFWork.EntityConfiguration
{
    public class UserNotificationConfiguration : EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguration()
        {
            HasRequired(e => e.User).
                 WithMany(e => e.UserNotifications).
                 WillCascadeOnDelete(false);
        }
    }
}