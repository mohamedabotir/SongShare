using GigsApplication.Core;
using GigsApplication.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GigsApplication.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult Index(string query = null,bool isFuture= false)
        {
            var upCommingGigs = unitOfWork.
                _gigRepo.GetAllAvailableGigsWithArtistAndGenre(isFuture); 
             
             
            if (!String.IsNullOrWhiteSpace(query))
            {
                upCommingGigs = upCommingGigs.Where(
                    g => g.Artist.name.Contains(query) ||
                    g.Genre.Name.Contains(query) ||
                    g.Song.Contains(query)
                );
            }
            var userId = User.Identity.GetUserId();

            var attendances = unitOfWork._attendanceRepo.
                GetFutureAttendances(userId)
               .ToLookup(e => e.GigId);
            var viewModel = new HomeViewModel
            {
                upCommingGigs = upCommingGigs,
                showActions = User.Identity.IsAuthenticated,
                Heading = isFuture?"Upcoming Share":"Availables Gigs",
                Search = query,
                attendances = attendances
            };
            return View("Gigs",  viewModel );
        }
        public ActionResult ScheduledShare() {
          return  RedirectToAction("Index", new {  isFuture = true });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }


}