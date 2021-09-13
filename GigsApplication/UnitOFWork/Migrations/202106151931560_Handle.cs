namespace GigsApplication.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Handle : DbMigration
    {
        public override void Up()
        {
            Sql("insert into genres (Id,Name)values(1,'Gazz')");
            Sql("insert into genres (Id,Name)values(2,'Rock')");
            Sql("insert into genres (Id,Name)values(3,'Blues')");
            Sql("insert into genres (Id,Name)values(4,'Country')");
        }

        public override void Down()
        {
            Sql("delete from genres where id in(1,2,3,4)");
        }
    }
}
