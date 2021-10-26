using GigsApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigsApplication.Core.Repositories
{
    public interface ILove
    {
        void AddLove(Love love);
        void removeLove(Love love);
        Love getLove(string userId, int audioId);
        IEnumerable<Love> GetLovesWithUserId(string id);
        IEnumerable<Love> GetLovesWithAudioId(int id);
    }
}