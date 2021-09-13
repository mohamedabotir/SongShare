using System;

namespace GigsApplication.Core.Dtos
{
    public class GigDto
    {
        public int Id { get; set; }

        public UserDto Artist { get; set; }
        public bool IsCanceled { get; private set; }

        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }



        public string Venue { get; set; }

        public GenreDto Genre { get; set; }

        public int GenreID { set; get; }

    }
}