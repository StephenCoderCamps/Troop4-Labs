namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "FavColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "FavColor");
        }
    }
}
