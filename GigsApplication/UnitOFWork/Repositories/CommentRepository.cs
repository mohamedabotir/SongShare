using GigsApplication.Core.Models;
using GigsApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            throw new NotImplementedException();
        }
    }
}