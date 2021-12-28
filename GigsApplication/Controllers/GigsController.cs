using GigsApplication.Core;
using GigsApplication.Core.Models;
using GigsApplication.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var userId = User.Identity.GetUserId();
            var artists = unitOFWork._followingRepo.GetMyFollowing(userId);
            var list = artists.ToList();
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
                attendances = unitOFWork._attendanceRepo.GetAttendances(userId)
              .ToLookup(e => e.GigId),
                action = "notified"

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
                Venue = gig.Song,
                SongData = gig.SongData,
                SongMimeType = gig.SongMimeType


            };
            return View("GigForm", GigView);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigsViewModel gigsView, HttpPostedFileBase sound)
        {

            if (!ModelState.IsValid)
            {
                gigsView.Genres = unitOFWork._genreRepo.GetGenre();
                return View("GigForm", gigsView);
            }
            gigsView.SongMimeType = sound.ContentType;
            gigsView.SongData = new byte[sound.ContentLength];
            sound.InputStream.Read(gigsView.SongData, 0, sound.ContentLength);

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                GenreID = gigsView.Genre,
                Song = gigsView.Venue,
                DateTime = gigsView.getDateTime(),
                SongMimeType = gigsView.SongMimeType,
                SongData = gigsView.SongData
            };
            var artists = unitOFWork._followingRepo.GetMyFollowers(User.Identity.GetUserId());
            unitOFWork._gigRepo.Add(gig);
            var notification = Notification.CreateNotification(gig);
            var list = artists.ToList();
            foreach (var item in list)
            {
                item.Follower.Notify(notification);

            }
            unitOFWork.complete();
            return RedirectToAction("MyGig");
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigsViewModel gigsView, HttpPostedFileBase sound)
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
            if (sound != null)
            {
                gigsView.SongMimeType = sound.ContentType;
                gigsView.SongData = new byte[sound.ContentLength];
                sound.InputStream.Read(gigsView.SongData, 0, sound.ContentLength);
            }
            else
            {
                gigsView.SongMimeType = gig.SongMimeType;
                gigsView.SongData = gig.SongData;
            }
            gig.Update(gigsView.Venue, gigsView.getDateTime(), gigsView.Genre, gigsView.SongData, gigsView.SongMimeType);
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
            var userId = User.Identity.GetUserId();
            var gigDetails = unitOFWork._gigRepo.GetGigWithArtistAndGenre(id);
            if (gigDetails == null)
            {
                return HttpNotFound();
            }
            GigDetailsViewModel gig = new GigDetailsViewModel
            {
                gigs = gigDetails
            };
            var comments = unitOFWork._commentRepo.GetComments(id).ToList();
            if (User.Identity.IsAuthenticated)
            {
                gig.IsAttending = unitOFWork._attendanceRepo.GetAttendance(id, userId) != null;
                gig.IsFollowing = unitOFWork._followingRepo.GetFollower(userId, gigDetails.ArtistId) != null;
                gig.IsLoved = unitOFWork._loveRepo.getLove(userId, id) != null;

                gig.Username = unitOFWork._commentRepo.getCommentedUsername(userId);
            }
            gig.Comments = comments;
            return View(gig);
        }
        public FileContentResult getSound(int soundId)
        {
            var record = unitOFWork._gigRepo.GetGig(soundId);
            if (record != null)
            {
                if (record.SongData.Length == 0)
                    return null;
                return File(record.SongData, record.SongMimeType);

            }
            else
                return null;
        }
    }


}