namespace GigsApplication.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "Genre_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Gigs", "Genre_Id");
            AddForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            DropColumn("dbo.Gigs", "Genre_Id");
        }
    }
}
