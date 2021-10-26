namespace GigsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLoveFieldGig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "Love", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gigs", "Love");
        }
    }
}
