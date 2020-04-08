using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Migrations;
using Vidly.Models;
using Vidly.ViewModels;
namespace Vidly.Controllers
{
    public class MoviesController : Controller
        //this class is the controller of the Movie model. As Controller, this is responsible for passing the objects from Model(movie) to the View(Random)
        //and to handle the HTTP requests
    {
        private ApplicationDbContext _context;  
        public MoviesController()
        {
            _context = new ApplicationDbContext();  //here we initialize that object. This helps proper dispose
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {

            var movies = _context.Movies.Include(c => c.Genre).ToList();  //this is a Dbset to define in our Db context. 

            return View(movies);
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

        /*
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
        */
        public ActionResult ByReleaseDate(int year, byte month)
        {

            return Content(year+"/"+month);
            //the Content action here will print the year+month, given by us (user) in the navigation bar ( /movies/released/2015/11 for ex, 
            //will be printed like: 2015/11 in the body
            
        }


    }
}