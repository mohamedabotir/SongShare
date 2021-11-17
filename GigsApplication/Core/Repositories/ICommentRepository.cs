using GigsApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigsApplication.Core.Repositories
{
    public interface ICommentRepository
    {
        void postComment(Comment comment );
    }
}
