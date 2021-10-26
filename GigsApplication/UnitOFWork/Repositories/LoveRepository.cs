using GigsApplication.Core.Models;
using GigsApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigsApplication.UnitOFWork.Repositories
{
    public class LoveRepository : ILove
    {
        private readonly ApplicationDbContext _context;
        public LoveRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddLove(Love love)
        {
            _context.Loves.Add(love);
        }

        public Love getLove(string userId, int audioId)
        {
            return _context.Loves.
                Where(e => e.UserId == userId && e.audioId == audioId).
                FirstOrDefault();
        }

        public IEnumerable<Love> GetLovesWithAudioId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Love> GetLovesWithUserId(string id)
        {
            throw new NotImplementedException();
        }

        public void removeLove(Love love)
        {
            _context.Loves.Remove(love);
        }
    }
}