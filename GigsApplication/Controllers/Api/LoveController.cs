using GigsApplication.Core;
using GigsApplication.Core.Dtos;
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
       public IHttpActionResult loves([FromBody]GigDto gig) {
            var gigId = gig.Id;
            var audioData = unitOfWork._gigRepo.GetGig(gigId);
            if (audioData == null)
                return NotFound();
               var userId = User.Identity.GetUserId();
            var audioLove = unitOfWork._loveRepo.getLove(userId, gigId);
            if (audioLove != null)
                return BadRequest("some thing gone error please Refresh");
            Love love = new Love{
            UserId = userId,
            audioId = gigId
            };
            unitOfWork._loveRepo.AddLove(love);
            unitOfWork.complete();

            //return Created($"/gigs/details/{gigId}", gigId);
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
            return Ok(id);
        }
    }
}
