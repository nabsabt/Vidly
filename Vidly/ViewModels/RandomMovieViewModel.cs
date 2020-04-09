using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
    //as we use Models folder for only domain classes, we create another folder, ViewModels
    //This ViewModel class connects the Model domain classes with the View
{
    public class RandomMovieViewModel
    {
        //we set up two properties, a Movie type Movie for the movies, and a Customer-type List for customers
        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
        public List<Customer> Customers { get; set; }

        public string Title
        {
            get
            {
                if (Movie != null && Movie.ID != 0) 
                return "Edit Movie";

                return "New Movie";
            }
        }
    }
}