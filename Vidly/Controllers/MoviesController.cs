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

        public ViewResult New()    /// add a new movie
        {
            var genres = _context.Genres.ToList();
            var viewModel = new RandomMovieViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
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
            var movie = _context.Movies.SingleOrDefault(c => c.ID == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

      
       
        public ActionResult ByReleaseDate(int year, byte month)
        {

            return Content(year+"/"+month);
            //the Content action here will print the year+month, given by us (user) in the navigation bar ( /movies/released/2015/11 for ex, 
            //will be printed like: 2015/11 in the body
            
        }



        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            Vidly.Models.Movie dbMovie = new Movie()
            {
                Name = movie.Name,

                GenreID =  movie.GenreID
            };

            _context.Movies.Add(dbMovie);
            

            //if (movie.ID == 0)
            //{
                
            //    _context.Movies.Add(movie);
            //}
            //{
            //   var movieInDb = _context.Movies.Single(m => m.ID == movie.ID);
            //    movieInDb.Name = movie.Name;
            //    movieInDb.GenreID = movie.GenreID;
            //}

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");

        }
    }
}