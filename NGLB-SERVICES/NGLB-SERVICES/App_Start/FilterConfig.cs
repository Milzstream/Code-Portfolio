using System.Web.Mvc;

namespace NGLB_SERVICES
{
    /// <summary>
    ///     Microsoft Filter Config
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        ///     Registers the ErrorHandleAttribute
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
