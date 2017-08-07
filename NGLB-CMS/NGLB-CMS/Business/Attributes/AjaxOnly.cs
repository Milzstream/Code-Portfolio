using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGLB_CMS.Business
{
    public class AjaxOnlyAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
                throw new InvalidOperationException(string.Format(
                    CultureInfo.CurrentCulture,
                    "The action '{0}' is accessible only by an ajax request.",
                    filterContext.ActionDescriptor.ActionName
                ));
        }
    }
}