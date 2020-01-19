using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AvisFormations.WebUi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           
            routes.MapRoute(
                name: "Contact",
                url: "Contactez-nous",
                defaults: new { controller = "Contact", action = "Index" }

                );
            routes.MapRoute(
              name: "ToutesLesFormations",
              url: "touteslesformations",
              defaults: new { controller = "Formations", action = "ToutesLesFormations" }

              );
            routes.MapRoute(
             name: "DetailsFormation",
             url: "formation/{nSeo}",
             defaults: new { controller = "Formations", action = "DetailsFormation" }

             );
            routes.MapRoute(
             name: "Ajouter",
             url: "Avis/{nSeo}/ajouter-avis",
             defaults: new { controller = "Avis", action = "LaisserUnAvis" }

             );
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
