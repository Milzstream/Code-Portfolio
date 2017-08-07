using System.Web.Mvc;
using System.Web.Routing;

namespace NGLB_SERVICES
{
    /// <summary>
    ///     Route for API
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        ///     Registers Routes
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

