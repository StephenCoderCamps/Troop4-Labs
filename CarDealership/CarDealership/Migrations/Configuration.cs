namespace CarDealership.Migrations
{
    using CarDealership.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealership.Models.ApplicationDbContext context)
        {
            var cars = new Car[]{
                new Car
                     { Title ="Cooper", Price = 3254.43m , Picture = "http://static.usnews.rankingsandreviews.com/images/Auto/izmo/366655/2014_mini_cooper_hardtop_angularfront.jpg" , 
                         BriefDescription="this is th mini cooper" , FullDescription= "say something about this mini car" , Range = 100, ChargeTime= 5},
                new Car { Title ="Tesla", Price = 53254.43m , Picture = "http://www.ecnmag.com/sites/ecnmag.com/files/embedded_image/2015/09/Tesla_Model_S_Indoors.jpg" , 
                     BriefDescription="this is stephens tesla" , FullDescription= "say something about this his car" , Range = 270, ChargeTime= 3}

            
            };
            context.Cars.AddOrUpdate(c => c.Title, cars);
        }
    }
}
