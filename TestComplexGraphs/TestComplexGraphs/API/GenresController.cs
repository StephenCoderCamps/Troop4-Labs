using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestComplexGraphs.Models;
using System.Data.Entity;

namespace TestComplexGraphs.API
{
    public class GenresController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();


        public HttpResponseMessage Get()
        {
            var genres = _db.Genres
                .Include(g => g.Movies)
                .Include(g => g.Movies.Select(m => m.Actors))
                .ToList();

            return Request.CreateResponse(HttpStatusCode.OK, genres);
        }


        public HttpResponseMessage Get(int id)
        {
            var genre = _db.Genres
                .Include(g => g.Movies)
                .Include(g => g.Movies.Select(m => m.Actors))
                .Where(g => g.Id == id)
                .FirstOrDefault();

            return Request.CreateResponse(HttpStatusCode.OK, genre);
        }

    }


}
