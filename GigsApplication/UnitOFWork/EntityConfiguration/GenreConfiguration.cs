using GigsApplication.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigsApplication.UnitOFWork.EntityConfiguration
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}