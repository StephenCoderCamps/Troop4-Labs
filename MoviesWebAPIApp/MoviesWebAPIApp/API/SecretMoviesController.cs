using MoviesWebAPIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MoviesWebAPIApp.API
{
     [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SecretMoviesController : ApiController
    {
        [Authorize]
        public IEnumerable<Movie> Get() {
            return new List<Movie>
            {
                new Movie {Id=1, Title="Star Wars - Ewoks Revenge!"},
                new Movie {Id=1, Title="Spock versus Godzilla"},
                new Movie {Id=1, Title="Terminators, Zombies, and Dinosaurs"}
            };
        } 
    
    }
}
