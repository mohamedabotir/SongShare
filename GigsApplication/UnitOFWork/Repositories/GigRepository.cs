using GigsApplication.Core.Models;
using GigsApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigsApplication.UnitOFWork.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly ApplicationDbContext _context;

        public GigRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public Gig GetGigWithAttendances(int gigId)
        {
            return
                 //_context.Gigs.Include(s => Enumerable.Select<Attendance, ApplicationUser>(s.Attendences, d => d.Attendee)).
                 //SingleOrDefault(e => e.Id == gigId)
                 _context.Gigs.Include(s => s.Attendences.Select(e => e.Attendee)).
                     SingleOrDefault(e => e.Id == gigId); ;
        }

        public Gig GetGigWithArtistAndGenre(int id)
        {

            return
                 _context.Gigs.
                Include(e => e.Artist).Include(e => e.Genre).
                SingleOrDefault(e => e.Id == id);

        }
        public Gig GetGig(int id)
        {
            return
                _context.Gigs.
                SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<Gig> GetMyGigsWithGenreByArtist(string artistId)
        {
            return
                _context.Gigs.
                Where(e => e.ArtistId == artistId && e.DateTime > System.DateTime.Now && !e.IsCanceled).
                Include(e => e.Genre)
                ;
        }

        public IEnumerable<Gig> GetAllAvailableGigsWithArtistAndGenre()
        {
            return
                _context.Gigs.
                    Include(e => e.Artist)
                    .Include(e => e.Genre)
                    .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);
            ;
        }

        public Gig CancelGig(string userId, int gigId)
        {
            return
            _context.Gigs.Include(e => e.Attendences.Select(s => s.Attendee)).
                SingleOrDefault(e => e.Id == gigId && userId == e.ArtistId);
        }

        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                            .Where(e => e.AttendeeId == userId)
                            .Select(e => e.Gig).
                             Include(e => e.Artist)
                             .Include(e => e.Genre)
                            .ToList();
        }

        public void Add(Gig gig)
        {
            _context.Gigs.Add(gig);
        }
    }
}