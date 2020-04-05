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

        public ActionResult Edit (int id)
        {
            return Content("id=" + id);
            //here I create an action. The parameter "id" takes a value, and the Content() method prints it out.
            //I can check it by typing /movies/edit/1, where the movies is the controller(?), the /edit calls the action result, and the /1 is the
            //optional parameter, we pass. It can be whatever we want in this case

            //// the parameter must be named "id" in this case, as in RouteConfig line 18 we call it {id}:
            //url: "{controller}/{action}/{id}"
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            //we marked pageIndex nullable (optional) with sign "?". sortBy is a reference type (string), so its nullable by default
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            //if pageIndex paramater is not defined, we start with the index 1, if sortBy is not defined, we sort by Name

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        public ActionResult ByReleaseDate(int year, byte month)
        {

            return Content(year+"/"+month);
            //the Content action here will print the year+month, given by us (user) in the navigation bar ( /movies/released/2015/11 for ex, 
            //will be printed like: 2015/11 in the body
            
        }
        
    }
}