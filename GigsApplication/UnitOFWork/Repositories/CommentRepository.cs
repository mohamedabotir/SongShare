using GigsApplication.Core.Models;
using GigsApplication.Core.Repositories;

namespace GigsApplication.UnitOFWork.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        IApplicationDbContext _context;
        public CommentRepository(IApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public void postComment(Comment comment)
        {
            _context.Comments.Add(comment);
        }
    }
}