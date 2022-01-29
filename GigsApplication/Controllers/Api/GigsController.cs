using GigsApplication.Core;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigsApplication.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private IUnitOfWork unitOfWork;
        public GigsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = unitOfWork._gigRepo.CancelGig(userId, id);
            if (gig == null)
                return NotFound();
            if (gig.IsCanceled)
                return NotFound();

            if (gig.ArtistId != userId)
                return Unauthorized();
            gig.Cancel();

            unitOfWork.complete();
            return Ok();
        }
    }
}
