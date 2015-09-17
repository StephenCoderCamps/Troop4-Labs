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
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/Movies
        public IEnumerable<Movie> Get()
        {
            return _db.Movies.OrderByDescending(m => m.Id).Take(25).ToList();
        }

        // GET: api/Movies/5
        public HttpResponseMessage Get(int id)
        {
            var movie = _db.Movies.Find(id);
            if (movie == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, movie);
        }

        // POST: api/Movies
        [Authorize]
        public HttpResponseMessage Post(Movie movie)
        {
            if (ModelState.IsValid) {
                if (movie.Id == 0) {
                    _db.Movies.Add(movie);
                    _db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, movie);
                }
                else {
                    var original = _db.Movies.Find(movie.Id);
                    original.Title = movie.Title;
                    original.IMDBLink = movie.IMDBLink;
                    _db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, movie);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
        }

      

        // DELETE: api/Movies/5
        [Authorize]
        public HttpResponseMessage Delete(int id)
        {
            var movie = _db.Movies.Find(id);
            if (movie == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            _db.Movies.Remove(movie);
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
