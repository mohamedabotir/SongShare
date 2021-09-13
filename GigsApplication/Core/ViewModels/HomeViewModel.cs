using System.Collections.Generic;
using System.Linq;
using GigsApplication.Core.Models;

namespace GigsApplication.Core.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> upCommingGigs { set; get; }
        public string Heading { get; set; }
        public bool showActions { get; set; }
        public string Search { get; set; }

        public ILookup<int, Attendance> attendances { get; set; }
    }
}