using GigsApplication.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigsApplication.UnitOFWork.EntityConfiguration
{
    public class UserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfiguration()
        {
            Property(e => e.name).IsRequired()
                .HasMaxLength(70);

            HasMany(e => e.Followers).
            WithRequired(e => e.Followee).
            WillCascadeOnDelete(false);


            HasMany(e => e.Followees).
            WithRequired(e => e.Follower).
            WillCascadeOnDelete(false);

            HasMany(e => e.Comments).
                WithRequired(e => e.User).
                WillCascadeOnDelete(true);
        }
    }
}