using GigsApplication.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigsApplication.UnitOFWork.EntityConfiguration
{
    public class GigConfiguration : EntityTypeConfiguration<Gig>
    {
        public GigConfiguration()
        {
            Property(e => e.ArtistId)
                 .IsRequired();

            Property(e => e.Song)
                  .IsRequired()
                  .HasMaxLength(255);

            Property(e => e.GenreID)
                 .IsRequired();
            HasMany(g => g.Attendences)
                .WithRequired(a => a.Gig).WillCascadeOnDelete(false);
            Property(e => e.SongData)
                .IsRequired();
            Property(e => e.SongMimeType)
                .IsRequired();
        }
    }
}