using AutoMapper;
using GigsApplication.Core;
using GigsApplication.Core.Dtos;
using GigsApplication.Core.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GigsApplication.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private IUnitOfWork unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        public IEnumerable<NotificationDto> GetNotification()
        {
            var userId = User.Identity.GetUserId();

            var notifications = unitOfWork._notificationRepo.GetMyNotifications(userId);

            var notificationMap = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<ApplicationUser, UserDto>();
               cfg.CreateMap<Gig, GigDto>();
               cfg.CreateMap<Notification, NotificationDto>();

           });

            var mpp = new Mapper(notificationMap);

            return notifications.Select(mpp.Map<Notification, NotificationDto>);

        }
        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var user = User.Identity.GetUserId();
            var notifications = unitOfWork._notificationRepo.GetUnReadNotification(user);
            notifications.ForEach(e => e.Read());
            unitOfWork.complete();
            return Ok();
        }
    }
}
