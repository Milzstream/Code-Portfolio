using Business.Business;
using NoGuardianLeftBehind.App_Start;
using NoGuardianLeftBehind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoGuardianLeftBehind.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [AjaxOnly]
        public String SendContact(String name, String email, String body)
        {
            About about = new About();
            return about.ContactUs(name, email, body);
        }
    }
}