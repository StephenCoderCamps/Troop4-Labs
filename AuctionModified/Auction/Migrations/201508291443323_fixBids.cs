namespace Auction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixBids : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bids", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bids", "Name", c => c.String());
        }
    }
}
