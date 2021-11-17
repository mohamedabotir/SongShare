using GigsApplication.Core.Dtos;
using System.Web.Http;

namespace GigsApplication.Controllers.Api
{
    public class CommentController : ApiController
    {
        [HttpPost]
        public IHttpActionResult comment(CommentDto data)
        {

            return Ok();
        }
    }
}
