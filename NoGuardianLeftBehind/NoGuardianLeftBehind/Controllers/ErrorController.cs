using NoGuardianLeftBehind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoGuardianLeftBehind.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound(String id)
        { 
            return View();
        }

        public ActionResult ServerError(String id)
        {
            return View();
        }
    }
}