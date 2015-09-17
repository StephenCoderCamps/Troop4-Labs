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
    public class GuestbookController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/guestbook
        public IEnumerable<Entry> Get()
        {
            return _db.Entries.OrderByDescending(e => e.Id).Take(25).ToList();
        }

        // GET: api/guestbook/5
        public HttpResponseMessage Get(int id)
        {
            var entry = _db.Entries.Find(id);
            if (entry == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, entry);
        }

        // POST: api/guestbook
        [Authorize]
        public HttpResponseMessage Post(Entry entry)
        {
            if (ModelState.IsValid) {
                if (entry.Id == 0) {
                    _db.Entries.Add(entry);
                    _db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, entry);
                }
                else {
                    var original = _db.Entries.Find(entry.Id);
                    original.Author = entry.Author;
                    original.Message = entry.Message;
                    _db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entry);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
        }

      

        // DELETE: api/guestbook/5
        [Authorize]
        public HttpResponseMessage Delete(int id)
        {
            var entry = _db.Entries.Find(id);
            if (entry == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            _db.Entries.Remove(entry);
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    
    }
}
