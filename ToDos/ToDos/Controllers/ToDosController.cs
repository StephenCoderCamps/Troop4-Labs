using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDos.Models;
using ToDos.Services;

namespace ToDos.Controllers
{
    public class ToDosController : ApiController
    {
        private IToDoService _toDoService;

        public ToDosController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }





        // GET: api/ToDos
        public IList<ToDo> Get()
        {
            return _toDoService.List();
        }

        // GET: api/ToDos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ToDos
        public HttpResponseMessage Post(ToDo toDo)
        {
            if (ModelState.IsValid) {
                _toDoService.CreateToDo(toDo);
                return Request.CreateResponse(HttpStatusCode.Created, toDo);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
        }

        // PUT: api/ToDos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ToDos/5
        public void Delete(int id)
        {
        }
    }
}
