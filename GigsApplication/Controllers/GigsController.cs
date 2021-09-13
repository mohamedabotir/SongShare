using GigsApplication.UnitOFWork;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using GigsApplication.Core;
using GigsApplication.Core.Models;
using GigsApplication.Core.ViewModels;

namespace GigsApplication.Controllers
{
    public class GigsController : Controller
    {




        private IUnitOfWork unitOFWork;
        public GigsController(IUnitOfWork unitOFWork)
        {


            this.unitOFWork = unitOFWork;
        }
        [Authorize]
        public ActionResult MyGig()
        {
            var gigs = unitOFWork._gigRepo.GetMyGigsWithGenreByArtist(User.Identity.GetUserId()).ToList();
            return View(gigs);
        }
        [Authorize]
        public ActionResult Following()
        {
            var artists = unitOFWork._followingRepo.GetMyFollowing(User.Identity.GetUserId());

            var Following = new FollowingViewModel()
            {
                followingArtist = artists
            };
            return View(Following);
        }
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new HomeViewModel
            {
                upCommingGigs = unitOFWork._gigRepo.GetGigsUserAttending(userId),
                showActions = User.Identity.IsAuthenticated,
                Heading = "Gigs i'am attending",
                attendances = unitOFWork._attendanceRepo.GetFutureAttendances(userId)
              .ToLookup(e => e.GigId)
            };
            return View("Gigs", viewModel);
        }





        [Authorize]
        public ActionResult Create()
        {
            var GigView = new GigsViewModel()
            {
                Heading = "Create a Gig",
                Genres = unitOFWork._genreRepo.GetGenre()
            };
            return View("GigForm", GigView);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var gig = unitOFWork._gigRepo.GetGig(id);
            if (gig == null)

                return HttpNotFound();

            if (User.Identity.GetUserId() != gig.ArtistId)
                return new HttpUnauthorizedResult();
            var GigView = new GigsViewModel()
            {
                id = gig.Id,
                Heading = "Edit a Gig",
                Genres = unitOFWork._genreRepo.GetGenre(),
                Date = gig.DateTime.ToString("dd MMM yyyy"),
                Time = gig.DateTime.ToString("HH:mm"),
                Genre = gig.GenreID,
                Venue = gig.Venue

            };
            return View("GigForm", GigView);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigsViewModel gigsView)
        {

            if (!ModelState.IsValid)
            {
                gigsView.Genres = unitOFWork._genreRepo.GetGenre();
                return View("GigForm", gigsView);
            }
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                GenreID = gigsView.Genre,
                Venue = gigsView.Venue,
                DateTime = gigsView.getDateTime()
            };
            unitOFWork._gigRepo.Add(gig);

            unitOFWork.complete();
            return RedirectToAction("MyGig");
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigsViewModel gigsView)
        {
            if (!ModelState.IsValid)
            {
                gigsView.Genres = unitOFWork._genreRepo.GetGenre();
                return View("GigForm", gigsView);
            }
            var gig = unitOFWork._gigRepo.GetGigWithAttendances(gigsView.id);
            if (gig == null)
            {
                return HttpNotFound();
            }
            if (gig.ArtistId != User.Identity.GetUserId())
            {
                return new HttpUnauthorizedResult();
            }

            gig.Update(gigsView.Venue, gigsView.getDateTime(), gigsView.Genre);
            unitOFWork.complete();
            return RedirectToAction("MyGig");
        }
        [HttpPost]
        public ActionResult search(HomeViewModel gigsViewModel)
        {
            return RedirectToAction("Index", "Home", new { query = gigsViewModel.Search });

        }
        public ActionResult details(int id)
        {
            var gigDetails = unitOFWork._gigRepo.GetGigWithArtistAndGenre(id);
            if (gigDetails == null)
            {
                return HttpNotFound();
            }
            GigDetailsViewModel gig = new GigDetailsViewModel
            {
                gigs = gigDetails
            };
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                gig.IsAttending = unitOFWork._attendanceRepo.GetAttendance(id, userId) != null;
                gig.IsFollowing = unitOFWork._followingRepo.GetFollower(userId, gigDetails.ArtistId) != null;


            }
            return View(gig);
        }
    }


}