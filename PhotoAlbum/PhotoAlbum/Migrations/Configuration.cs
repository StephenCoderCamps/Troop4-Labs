namespace PhotoAlbum.Migrations
{
    using PhotoAlbum.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoAlbum.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhotoAlbum.Models.ApplicationDbContext context)
        {
            var albums = new Album[] 
                {
                new Album 
                
                {
                    AlbumName = "CoderCamps",
                    Photos = new List<Photo> 
                    {
                        new Photo
                        {
                            Title = "Shovel", Description = "Love Digging", Location = "http://i.imgur.com/xLIqZTF.png", Rating = PhotoRating.Terrible
                        },

                        new Photo
                        {
                            Title = "Marvel", Description = "Movies and shows", Location = "http://i.imgur.com/d9WeTAv.jpg", Rating = PhotoRating.Awesome
                        }
                        
                    }
                }  
                };
            context.Albums.AddOrUpdate(a => a.AlbumName, albums); 
          
        }
    }
}
