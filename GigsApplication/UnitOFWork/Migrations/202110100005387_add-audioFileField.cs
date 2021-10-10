namespace GigsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaudioFileField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "SongData", c => c.Binary(nullable: false));
            AddColumn("dbo.Gigs", "SongMimeType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gigs", "SongMimeType");
            DropColumn("dbo.Gigs", "SongData");
        }
    }
}
