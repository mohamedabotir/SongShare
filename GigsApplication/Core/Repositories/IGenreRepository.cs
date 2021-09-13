using System.Collections.Generic;
using GigsApplication.Core.Models;

namespace GigsApplication.Core.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenre();
    }
}