namespace MoviesWebAPIApp.Migrations
{
    using MoviesWebAPIApp.Infrastructure;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MoviesWebAPIApp.Models;
    using System.Security.Claims;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesWebAPIApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MoviesWebAPIApp.Models.ApplicationDbContext context)
        {
            // let's add some users
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            // Ensure Mike (admin)
            var mike = userManager.FindByName("Mike@CoderCamps.com");
            if (mike == null) {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                userManager.Create(mike, "Secret123!");

                // add claims
                userManager.AddClaim(mike.Id, new Claim("CanEditMovies", "true"));
                userManager.AddClaim(mike.Id, new Claim(ClaimTypes.DateOfBirth, "12/25/1977"));
            }
            // Ensure Alex (non-admin)
            var alex = userManager.FindByName("Alex@CoderCamps.com");
            if (alex == null) {
                // create user
                alex = new ApplicationUser
                {
                    UserName = "Alex@CoderCamps.com",
                    Email = "Alex@CoderCamps.com"
                };
                userManager.Create(alex, "Secret123!");
            }


            // Ensure one guestbook entry
            if (context.Entries.Count() == 0) {
                context.Entries.Add(new Entry()
                {
                    Author="Stephen",
                    DateCreated = DateTime.Now,
                    Message = "Thanks for visiting Coder Camps!"
                });
            }


        }
    }
}
