namespace GigsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyLove : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loves",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        audioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.audioId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Gigs", t => t.audioId)
                .Index(t => t.UserId)
                .Index(t => t.audioId);
            
            DropColumn("dbo.Gigs", "Love");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gigs", "Love", c => c.Int());
            DropForeignKey("dbo.Loves", "audioId", "dbo.Gigs");
            DropForeignKey("dbo.Loves", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Loves", new[] { "audioId" });
            DropIndex("dbo.Loves", new[] { "UserId" });
            DropTable("dbo.Loves");
        }
    }
}
