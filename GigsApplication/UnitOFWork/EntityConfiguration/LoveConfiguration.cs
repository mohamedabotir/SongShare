using GigsApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GigsApplication.UnitOFWork.EntityConfiguration
{
    public class LoveConfiguration:EntityTypeConfiguration<Love>
    {
        public LoveConfiguration()
        {
            Property(e => e.UserId).HasColumnOrder(1).IsRequired();
            Property(e => e.audioId).HasColumnOrder(2).IsRequired();

        }
    }
}