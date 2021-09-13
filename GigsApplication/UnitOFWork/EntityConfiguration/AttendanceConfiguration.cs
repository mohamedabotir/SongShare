using GigsApplication.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigsApplication.UnitOFWork.EntityConfiguration
{
    public class AttendanceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            Property(e => e.GigId).HasColumnOrder(1).IsRequired();
            Property(e => e.AttendeeId).HasColumnOrder(2).IsRequired();

        }
    }
}