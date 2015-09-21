namespace TestComplexGraphs.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestComplexGraphs.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestComplexGraphs.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestComplexGraphs.Models.ApplicationDbContext context)
        {
            context.Database.ExecuteSqlCommand("DELETE FROM Actors");
            context.Database.ExecuteSqlCommand("DELETE FROM Movies");
            context.Database.ExecuteSqlCommand("DELETE FROM Genres");

            // create genres
            var scifi = new Genre { Name = "SciFi" };
            var drama = new Genre { Name = "Action" };


            // add actors
            var harrisonFord = new Actor
            {
                Name = "Harrison Ford"
            };
            var markHamill = new Actor {
                Name = "Mark Hamill"
            };
            var sigourneyWeaver = new Actor
            {
                Name = "Sigourney Weaver"
            };
            var brando = new Actor
            {
                Name = "Brando"
            };


            // add movies
            var starWars = new Movie { 
                Genre = scifi,
                Title = "Star Wars", 
                Actors = new List<Actor> {
                    harrisonFord,
                    markHamill
                }
            };
            context.Movies.Add(starWars);

            var aliens = new Movie
            {
                Genre = scifi,
                Title = "Aliens",
                Actors = new List<Actor>
                {
                    harrisonFord,
                    sigourneyWeaver
                }
            };
            context.Movies.Add(aliens);

            var godfather = new Movie
            {
                Genre = drama,
                Title = "The Godfather",
                Actors = new List<Actor>
                {
                    brando
                }
            };
            context.Movies.Add(godfather);



        }
    }
}
