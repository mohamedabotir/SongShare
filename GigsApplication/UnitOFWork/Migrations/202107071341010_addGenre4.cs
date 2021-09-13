namespace GigsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenre4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Gigs", "GenreID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gigs", "GenreID", c => c.Byte(nullable: false));
        }
    }
}
