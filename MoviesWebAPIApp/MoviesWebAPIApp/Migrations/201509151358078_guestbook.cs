namespace MoviesWebAPIApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guestbook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        Author = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Entries");
        }
    }
}
