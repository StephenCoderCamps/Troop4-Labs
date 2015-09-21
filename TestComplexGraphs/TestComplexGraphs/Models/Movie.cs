using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestComplexGraphs.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [JsonIgnore]
        public Genre Genre { get; set; }
        [JsonIgnore]
        public int GenreId { get; set; }

        public ICollection<Actor> Actors { get; set; }
    }
}