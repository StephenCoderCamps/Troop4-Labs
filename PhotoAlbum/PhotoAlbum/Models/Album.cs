using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public ICollection<Photo> Photos { get; set; }
                                 
    }
}