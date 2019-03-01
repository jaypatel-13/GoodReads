using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GoodReads
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Login1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Users", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Register",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Users", action = "Register", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "ShowBooks",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "BookDetails", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "ShowBooks2",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "BookDetails", action = "Index2", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "ShowBooks3",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "BookDetails", action = "Index3", id = UrlParameter.Optional }
          );
            routes.MapRoute(
             name: "UploadBook",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "BookDetails", action = "Create", id = UrlParameter.Optional }
         );
            routes.MapRoute(
             name: "DeleteBook",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "BookDetails", action = "Delete", id = UrlParameter.Optional }
         );
            routes.MapRoute(
            name: "DeleteBookConfirmed",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "BookDetails", action = "DeleteConfirmed", id = UrlParameter.Optional }
        );
            routes.MapRoute(
               name: "Logout",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Users", action = "Logout", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Edit",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Users", action = "Edit", id = UrlParameter.Optional }
           );
           
        }
    }
}
