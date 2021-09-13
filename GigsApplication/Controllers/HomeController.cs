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
        public ActionResult Index(string query = null)
        {
            var upCommingGigs = unitOfWork.
                _gigRepo.GetAllAvailableGigsWithArtistAndGenre();
            if (!String.IsNullOrWhiteSpace(query))
            {
                upCommingGigs = upCommingGigs.Where(
                    g => g.Artist.name.Contains(query) ||
                    g.Genre.Name.Contains(query) ||
                    g.Venue.Contains(query)
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
                Heading = "Availables Gigs",
                Search = query,
                attendances = attendances
            };
            return View("Gigs", viewModel);
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