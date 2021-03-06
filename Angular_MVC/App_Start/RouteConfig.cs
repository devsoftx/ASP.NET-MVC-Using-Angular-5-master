﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Angular_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "App", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "DefaultPublic",
               url: "public/",
               defaults: new { controller = "Public", action = "Index" }
           );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{*.}",
            //    defaults: new { controller = "Home", action = "Index" }
            //);
        }
    }
}
