using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigsApplication.Core.Models
{
    public class Love
    {
        public ApplicationUser User { get; set; }
        public Gig Audio { get; set; }
        [Key]
        public string UserId { get; set; }
        [Key]
        public int audioId { set; get; }
    }
}