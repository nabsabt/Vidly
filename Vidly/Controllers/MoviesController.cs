using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
        //this class is the controller of the Movie model. As Controller, this is responsible for passing the objects from Model(movie) to the View(Random)
        //and to handle the HTTP requests
    {
        // GET: Movies
        public ActionResult Random()
            //this method is an actionresult
        {
            Movie movie = new Movie() {Name = "Shawhank Redemption"};
            //here I created a Movie object, called "movie". I gave property "Name" a value: "Shawhank Redemption"


            return View(movie);
            //I added the movie object (Model) to the View as parameter. This will render the movie Model, by the rules, seen in the Random.cshtml file (View)
            //ViewResult (View) is one of the ActionResults, that is why this method can return it, though in the initialization, its type is ActionResult
            // ViewResult is an ActionResult type, View() is the helper method of it
        }
    }
}