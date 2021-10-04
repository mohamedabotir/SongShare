using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FluentAssertions;
using Gig.Tests.Extensions;
using GigsApplication.UnitOFWork.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gig.Tests.UnitOfWork.Repositories
{
   
    [TestClass]
    public class GigsRepositoryTests
    {
        private GigRepository repository;
        Mock<DbSet<GigsApplication.Core.Models.Gig>> mockGig;
        [TestInitialize]
        public void TestInitialize()
        {
             mockGig = new Mock<DbSet<GigsApplication.Core.Models.Gig>>();
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Gigs).Returns(()=>mockGig.Object);
            repository = new GigRepository(mockContext.Object);
        }
        [TestMethod]
        public void UpCommingGigs_IsInThePast_ShouldReturnEmpty()
        {
            var gig = new GigsApplication.Core.Models.Gig
            { DateTime = DateTime.Now.AddDays(-1),ArtistId = "1"};

            mockGig.setProvidedSource(new List<GigsApplication.Core.Models.Gig> { gig });
            var repo = repository.GetMyGigsWithGenreByArtist("1");
            repo.Should().BeEmpty();
        }
        [TestMethod]
        public void UpCommingGigs_IsCanceled_ShouldReturnEmpty()
        {
            var gig = new GigsApplication.Core.Models.Gig
            { DateTime = DateTime.Now.AddDays(1), ArtistId = "1" };
            gig.Cancel();
            mockGig.setProvidedSource(new List<GigsApplication.Core.Models.Gig> { gig });
            var repo = repository.GetMyGigsWithGenreByArtist("1");
            repo.Should().BeEmpty();
        }
        [TestMethod]
        public void UpCommingGigs_NotArtistId_ShoudReturnEmpty()
        {
            var gig = new GigsApplication.Core.Models.Gig
            { DateTime = DateTime.Now.AddDays(1), ArtistId = "1" };
            
            mockGig.setProvidedSource(new List<GigsApplication.Core.Models.Gig> { gig });
            var repo = repository.GetMyGigsWithGenreByArtist("15");
            repo.Should().BeEmpty();
        }
        [TestMethod]
        public void UpComming_GigIsInTheFuture_ShouldReturnResult()
        {
            var gig = new GigsApplication.Core.Models.Gig
            { DateTime = DateTime.Now.AddDays(1), ArtistId = "1" };
            
            mockGig.setProvidedSource(new List<GigsApplication.Core.Models.Gig> { gig });
            var repo = repository.GetMyGigsWithGenreByArtist("1");
            repo.Should().Contain(gig);
        }
    }
}
