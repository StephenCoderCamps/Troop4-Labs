namespace MoviesWebAPIApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "IMDBLink", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "IMDBLink", c => c.String());
            AlterColumn("dbo.Movies", "Title", c => c.String());
        }
    }
}
