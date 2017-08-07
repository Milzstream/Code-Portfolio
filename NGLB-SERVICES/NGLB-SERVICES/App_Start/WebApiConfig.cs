using System.Web.Http;

namespace NGLB_SERVICES
{
    /// <summary>
    ///     Web API Config (useing Route Attributes)
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        ///     Registers default routes
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
