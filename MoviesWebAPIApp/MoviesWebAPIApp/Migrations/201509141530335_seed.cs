namespace MoviesWebAPIApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DateCreated");
        }
    }
}
