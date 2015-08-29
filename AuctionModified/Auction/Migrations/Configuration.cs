namespace Auction.Migrations
{
    using Auction.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Auction.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Auction.Models.ApplicationDbContext context)
        {
            var items = new Item[] {
                 new Item{
                   Name="Todd",
                   MinimumBid=1.00m,
                   NumOfBids= 2,
                   Description="Handsome",

                   Bids= new List<Bid> {
                        new Bid{Name = "Diane", BidAmount=25m},
                        new Bid{Name = "Jenny", BidAmount = 50m}
                   }



                  
            }

        };
            context.Items.AddOrUpdate(i => i.Name, items);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
