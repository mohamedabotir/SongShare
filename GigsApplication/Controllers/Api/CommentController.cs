using AutoMapper;
using GigsApplication.Core;
using GigsApplication.Core.Dtos;
using GigsApplication.Core.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigsApplication.Controllers.Api
{
    [Authorize]
    public class CommentController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;
        public CommentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IHttpActionResult comment(CommentDto data)
        {
            var comment = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentDto, Comment>();

            });
            data.Userid = User.Identity.GetUserId();
            var map = new Mapper(comment);
            var commentResult = map.Map<CommentDto, Comment>(data);
            unitOfWork._commentRepo.postComment(commentResult);
            unitOfWork.complete();
            return Ok();
        }
    }
}
