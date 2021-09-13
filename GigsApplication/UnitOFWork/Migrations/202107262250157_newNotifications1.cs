namespace GigsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newNotifications1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notifications", "newNotification");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "newNotification", c => c.Int(nullable: false));
        }
    }
}
