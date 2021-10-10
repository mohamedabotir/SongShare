namespace GigsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VenueToSong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "Song", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Gigs", "Venue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gigs", "Venue", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Gigs", "Song");
        }
    }
}
