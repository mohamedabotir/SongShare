using GigsApplication.Core.Models;
using GigsApplication.Core.Repositories;
using System.Collections.Generic;

namespace GigsApplication.UnitOFWork.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Genre> GetGenre()
        {
            return
                _context.Genres;
        }
    }
}