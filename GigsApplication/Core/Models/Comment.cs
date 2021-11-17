using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigsApplication.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int comment { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Gig Audio { get; set; }
        public int AudioId { get; set; }
    }
}