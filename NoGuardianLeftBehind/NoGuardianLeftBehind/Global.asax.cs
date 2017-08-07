using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Text;
using System.Threading;
using NoGuardianLeftBehind.Controllers;

namespace NoGuardianLeftBehind
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 30;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        private void Application_Error(object sender, EventArgs e)
        {
            string exceptionToLog = "";
            string errorOrigin = "";
            Exception exception;
            RouteData routeData = new RouteData();
            HttpException httpException;

            exception = Server.GetLastError().GetBaseException();
            Response.Clear();

            httpException = exception as HttpException;

            GetErrorInformation(ref exceptionToLog, ref errorOrigin, exception);

            if (httpException == null)
            {
                httpException = new HttpException(500, exceptionToLog, exception);
            }

            //routeData.DataTokens.Add("area", "");
            routeData.Values.Add("controller", "Error");

            switch (httpException.GetHttpCode())
            {
                //case 403: //Not Authorized
                //    routeData.Values.Add("action", "NotAllowed");

                //    break;

                case 404: //Page Not Found
                    routeData.Values.Add("action", "NotFound");
                    routeData.Values.Add("id", errorOrigin);

                    break;

                //case 707: // Not Implemented
                //    routeData.Values.Add("action", "NotImplemented");
                //    routeData.Values.Add("id", errorOrigin);

                //    break;

                case 500: //Server error
                    routeData.Values.Add("action", "ServerError");
                    routeData.Values.Add("id", errorOrigin);

                    // Code that runs when an unhandled error ocrrus
                    try
                    {
                        //Server.Transfer("~/Error/ServerError"); //Error Controller
                    }
                    catch (ThreadAbortException)
                    {
                        // Ignore this type of exception
                    }

                    break;

                default: //Default
                    routeData.Values.Add("action", "ServerError");
                    routeData.Values.Add("id", errorOrigin);

                    // Code that runs when an unhandled error ocrrus
                    try
                    {

                        //Server.Transfer("~/Error/ServerError"); //Error Controller
                    }
                    catch (ThreadAbortException)
                    {
                        // Ignore this type of exception
                    }
                    break;
            }

            //Means it is a partial
            if (errorOrigin.Split('/').Last().StartsWith("_"))
            {
                //Might do something special here
            }
            else
            {
                IController errorController = new ErrorController();
                errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
                (errorController as ErrorController).Dispose();
            }

            Server.ClearError();
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        private void GetErrorInformation(ref string loggableError, ref string errorOrigin, Exception lastException)
        {
            if (loggableError == null) throw new ArgumentNullException("loggableError");

            StringBuilder sb = new StringBuilder();
            String temp = String.Empty;
            RequestContext rCTX;
            //Exception lastException = Server.GetLastError().GetBaseException();

            // Create something to write to the application log
            sb.AppendFormat("Exception:\n{0}\n", lastException.Message);

            if (lastException.InnerException != null)
            {
                sb.AppendFormat("Inner Exception:\n{0}", lastException.InnerException.Message);
            }

            sb.AppendFormat("Stack Trace:\n{0}", lastException.StackTrace);

            loggableError = sb.ToString();

            sb.Clear();

            //Get the Context of where the Error Occured
            rCTX = ((MvcHandler)HttpContext.Current.CurrentHandler).RequestContext;

            //GEt The controller name
            temp = rCTX.RouteData.GetRequiredString("controller");

            if (!String.IsNullOrWhiteSpace(temp))
            {
                sb.Append("/");
                sb.Append(temp);
                sb.Append("/");
                sb.Append(rCTX.RouteData.GetRequiredString("action"));
            }

            errorOrigin = sb.ToString();
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new OutputCacheAttribute
            {
                VaryByParam = "*",
                Duration = 0,
                NoStore = true,
            });
        }
    }
}
