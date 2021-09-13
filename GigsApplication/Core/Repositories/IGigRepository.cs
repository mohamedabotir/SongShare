using GigsApplication.Core.Models;
using System.Collections.Generic;

namespace GigsApplication.Core.Repositories
{
    public interface IGigRepository
    {
        void Add(Gig gig);
        Gig GetGig(int id);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetGigWithArtistAndGenre(int id);
        Gig GetGigWithAttendances(int gigId);
        IEnumerable<Gig> GetMyGigsWithGenreByArtist(string artistId);
        IEnumerable<Gig> GetAllAvailableGigsWithArtistAndGenre();
        Gig CancelGig(string userId, int gigId);
    }
}