using GigsApplication.Core.Models;
using GigsApplication.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigsApplication.UnitOFWork.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        IApplicationDbContext _context;
        public CommentRepository(IApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public string getCommentedUsername(string id)
        {
            return _context.Users.SingleOrDefault(e => e.Id == id).name;
        }

        public List<Comment> GetComments(int id)
        {
            return _context.Comments.Where(e => e.AudioId == id).Include(e => e.User).ToList();
        }

        public void postComment(Comment comment)
        {
            _context.Comments.Add(comment);
        }
    }
}