using System.Web.Mvc;
using System.Web.Routing;

namespace ReedHampton
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AboutMe", action = "Home", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AlbumController",
                url: "{controller}/{action}/{albumId}/{albumName}",
                defaults: new { controller = "Images", action = "Albums", albumId = UrlParameter.Optional , albumName = UrlParameter.Optional  }
            );
        }
    }
}
