using System.Web.Http;
using System.Web.Mvc;

namespace NGLB_SERVICES
{
    /// <summary>
    ///     IDK Microsoft Stuff
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        ///     Starts App
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
        }
    }
}
