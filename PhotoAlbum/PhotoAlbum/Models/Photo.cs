using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public PhotoRating  Rating{ get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }

    }   
}