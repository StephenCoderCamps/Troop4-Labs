using MoviesWebAPIApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MoviesWebAPIApp.Infrastructure
{
    public class MovieLoader
    {

        enum CSVIndex
        {
            Id=0,
            Title=1,
            ReleaseDate=2,
            VideoReleaseDate=3,
            IMDBLink=4,
            Unknown=5,
            Action=6,
            Adventure=7,
            Animation=8,
            Childrens=9,
            Comedy=10,
            Crime=11,
            Documentary=12,
            Drama=13,
            Fantasy=14,
            Noir=15,
            Horror=16,
            Musical=17,
            Mystery=18,
            Romance=19,
            SciFi=20,
            Thriller=21,
            War=22,
            Western=23
        }

        public void LoadMovies()
        {
            // clear away all data
            var _db = new ApplicationDbContext();
            _db.Database.ExecuteSqlCommand("DELETE FROM Genres");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Genres', RESEED, 0);");
            _db.Database.ExecuteSqlCommand("DELETE FROM Movies");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Movies', RESEED, 0);");


            // add genres
            var genres = new Genre[] {
                new Genre() { Name = "Unknown" },
                new Genre() {Name="Action"},
                new Genre() { Name = "Adventure" },
                new Genre() { Name = "Animation" },
                new Genre() { Name = "Childrens" },
                new Genre() { Name = "Comedy" },
                new Genre() { Name = "Crime" },
                new Genre() { Name = "Documentary" },
                new Genre() { Name = "Drama" },
                new Genre() { Name = "Fantasy" },
                new Genre() { Name = "Noir" },
                new Genre() { Name = "Horror" },
                new Genre() { Name = "Musical" },
                new Genre() { Name = "Mystery" },
                new Genre() { Name = "Romance" },
                new Genre() { Name = "SciFi" },
                new Genre() { Name = "Thriller" },
                new Genre() { Name = "War" },
                new Genre() { Name = "Western" }
            };
            foreach (var genre in genres) {
                _db.Genres.Add(genre);
            }
            _db.SaveChanges();



            // add movies
            var moviesFile = Path.Combine(HttpRuntime.AppDomainAppPath, "movies.txt");
            using (StreamReader CsvReader = new StreamReader(moviesFile)) {
                string inputLine = "";

                while ((inputLine = CsvReader.ReadLine()) != null) {
                    var splitInput = inputLine.Split('|');
                    var genreIndex = 5;
                    for (var i=5;i<24;i++) {
                        if (splitInput[i] == "1") {
                            genreIndex = i;
                            break;
                        }
                    }
                    if (splitInput[(int)CSVIndex.Title] != "unknown" && splitInput[(int)CSVIndex.IMDBLink] != "") {
                        _db.Movies.Add(new Movie
                        {
                            Title = splitInput[(int)CSVIndex.Title],
                            IMDBLink = splitInput[(int)CSVIndex.IMDBLink],
                            GenreId = genres[genreIndex - 5].Id
                        });
                        _db.SaveChanges();
                    }
                }
                CsvReader.Close();
            }

        }
    }
}