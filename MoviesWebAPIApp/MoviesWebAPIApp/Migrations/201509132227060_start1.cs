namespace MoviesWebAPIApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "GenreId");
            AddColumn("dbo.Movies", "IMDBLink", c => c.String());
            AlterColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Director");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Director", c => c.String());
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "GenreId", c => c.Int());
            DropColumn("dbo.Movies", "IMDBLink");
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "Genre_Id");
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
