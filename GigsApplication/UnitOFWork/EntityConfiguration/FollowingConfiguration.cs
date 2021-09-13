using GigsApplication.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigsApplication.UnitOFWork.EntityConfiguration
{
    public class FollowingConfiguration : EntityTypeConfiguration<Following>
    {
        public FollowingConfiguration()
        {
            Property(e => e.FollowerId).HasColumnOrder(1).IsRequired();
            Property(e => e.FolloweeId).HasColumnOrder(2).IsRequired();
        }
    }
}