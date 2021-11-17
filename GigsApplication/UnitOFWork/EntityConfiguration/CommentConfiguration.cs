using GigsApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GigsApplication.UnitOFWork.EntityConfiguration
{
    public class CommentConfiguration :EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            Property(e => e.comment).IsRequired();
        }
    }
}