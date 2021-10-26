using GigsApplication.Core;
using GigsApplication.Core.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigsApplication.Controllers.Api
{   [Authorize]
    public class LoveController : ApiController
    {
        private IUnitOfWork unitOfWork;
        public LoveController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
       public IHttpActionResult loves(int id) {
            var audioData = unitOfWork._gigRepo.GetGig(id);
            if (audioData == null)
                return NotFound();
            var userId = User.Identity.GetUserId();
            Love love = new Love{
            UserId = userId,
            audioId = id
            };
            unitOfWork._loveRepo.AddLove(love);
            unitOfWork.complete();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult delete(int id) {
            var userId = User.Identity.GetUserId();
            var audioLove = unitOfWork._loveRepo.getLove(userId, id);
            if (audioLove == null)
                return NotFound();
            unitOfWork._loveRepo.removeLove(audioLove);
            unitOfWork.complete();
            return Ok();
        }
    }
}
