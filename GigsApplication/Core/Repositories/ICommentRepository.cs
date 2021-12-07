using GigsApplication.Core.Models;
using System.Collections.Generic;

namespace GigsApplication.Core.Repositories
{
    public interface ICommentRepository
    {
        void postComment(Comment comment);
        List<Comment> GetComments(int id);
        string getCommentedUsername(string id);
    }
}
