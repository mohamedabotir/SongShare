using GigsApplication.UnitOFWork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigs.IntegrationTests
{
    [SetUpFixture]
    class GlobalConfigurations
    {
        [SetUp]
        public void SetUp() {
            var configuration = new GigsApplication.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
            Seed();
        }
        public void Seed() {
            var context = new ApplicationDbContext();
            context.Users.Add(new GigsApplication.Core.Models.ApplicationUser { UserName="User1",name="User1",PasswordHash="-",Email="-"});
            context.Users.Add(new GigsApplication.Core.Models.ApplicationUser { UserName = "User2", name = "User2", PasswordHash = "-", Email = "-" });
            context.SaveChanges();
        }
    }
}
