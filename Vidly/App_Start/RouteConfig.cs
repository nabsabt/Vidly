using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //now we create a custom route. We need to add it before the default route, because the order of them matters. They needed to be defined from most
            //specific to most generic
            routes.MapRoute(
                "MoviesByReleaseDate",  //name of the route
                "movies/released/{year}/{month}", //url pattern of the route
                new {controller = "Movies", action = "ByReleaseDate"},
                //default: we set an anonym object with the name of controller and action name. 
                //We set the ByReleaseDate action in the controller (MoviesController) class.
                new { year= @"\d{4}", month=@"\d{2}"}  //here we make it look nicer, by setting year to 4 digits, and month to 2 digits in an anonym object
                                                       //This will force the user to add only 4 digits to year, and 2 for month in the url bar. If he types /2015/1, it will throw a 404 error
                );                                                     


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
