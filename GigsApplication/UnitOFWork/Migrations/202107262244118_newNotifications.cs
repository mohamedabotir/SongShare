namespace GigsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newNotifications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "newNotification", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "newNotification");
        }
    }
}
