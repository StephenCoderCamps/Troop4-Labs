using MoviesWebAPIApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesWebAPIApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("This is the Home Index Action");
        }


        public ActionResult Reset()
        {
            var loader = new MovieLoader();
            loader.LoadMovies();
            return Content("Database reset!");
        }
    }
}
