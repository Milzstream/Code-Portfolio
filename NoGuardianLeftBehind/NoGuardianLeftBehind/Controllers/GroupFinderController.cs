using Business.Enums;
using Business.Library;
using Data;
using Newtonsoft.Json;
using NoGuardianLeftBehind.App_Start;
using NoGuardianLeftBehind.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoGuardianLeftBehind.Controllers
{
    public class GroupFinderController : Controller
    {

        // GET: GroupFinder
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            Profile model = GetProfile();
          
            return View(model);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Finder(String Content, int? FireteamSize, int? MinimumLightLevel)
        {
            Profile profile = GetProfile();

            //Oh No!
            if (profile == null || String.IsNullOrWhiteSpace(Content) || FireteamSize == 0 || FireteamSize == null)
            {
                return RedirectToActionPermanent("Index", "GroupFinder");
            }

            ViewBag.MaxPlayers = FireteamSize;
            ViewBag.Content = Content;
            ViewBag.MinimumLightLevel = MinimumLightLevel;
            return View(profile);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult ContentSelection(String ContentType)
        {
            Profile profile = GetProfile();

            //Oh No!
            if (profile == null || String.IsNullOrWhiteSpace(ContentType))
            {
                return RedirectToActionPermanent("Index", "GroupFinder");
            }

            ViewBag.ContentType = ContentType;
            return View();
        }

        public ActionResult _GetAvailableContent(String ContentType)
        {
            Database db = new Database();
            Profile profile = GetProfile();
            List<Content> model = db.GetAvailableContent(profile.LightLevel, profile.Platform, ContentType);
            ViewBag.ContentType = ContentType.ToLower();
            return View(model);
        }

        [AjaxOnly]
        public ActionResult _Profile()
        {
            //Variables
            Profile model = GetProfile();

            return View(model);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult _ProfileWithPram(String Username, String Class, String Platform, int LightLevel, Boolean HasMic, Boolean RequireMic)
        {
            Profile model = new Profile(Username, Class, Platform, LightLevel, HasMic, RequireMic);
            return View("_Profile", model);
        }

        [AjaxOnly]
        public ActionResult _ProfileEdit()
        {
            //Variables
            Profile model = GetProfile();

            return View(model);
        }

        [AjaxOnly]
        public ActionResult _ProfileView()
        {
            //Variables
            Profile model = GetProfile();

            return View(model);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult _CreateSession(String Username, String Class, String Platform, int LightLevel, Boolean HasMic, Boolean RequireMic)
        {
            HttpCookie cookie = Request.Cookies.Get(SESSION.PROFILE);

            if (cookie == null)
            {
                cookie = new HttpCookie(SESSION.PROFILE);
                cookie.Values.Add("Username", Username);
                cookie.Values.Add("Class", Class);
                cookie.Values.Add("Platform", Platform);
                cookie.Values.Add("LightLevel", LightLevel.ToString());
                cookie.Values.Add("HasMic", HasMic.ToString());
                cookie.Values.Add("RequireMic", RequireMic.ToString());
            }
            else
            {
                cookie.Values["Username"] = Username;
                cookie.Values["Class"] = Class;
                cookie.Values["Platform"] = Platform;
                cookie.Values["LightLevel"] = LightLevel.ToString();
                cookie.Values["HasMic"] = HasMic.ToString();
                cookie.Values["RequireMic"] = RequireMic.ToString();
            }

            cookie.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(cookie);

            if (Session[SESSION.PROFILE] == null)
            {
                Session.Add(SESSION.PROFILE, new Profile(Username, Class, Platform, LightLevel, HasMic, RequireMic));
            }
            else
            {
                Session[SESSION.PROFILE] = new Profile(Username, Class, Platform, LightLevel, HasMic, RequireMic);
            }

            return Json(new { Success = true });
        }

        [AjaxOnly]
        public ActionResult _AdditionalOptions(int? MinimumLightLevel, String Content)
        {
            Database db = new Database();
            AdditionalOptions model = new AdditionalOptions(db.GetContentCheckpoints(Content));

            ViewBag.MinimumLightLevel = MinimumLightLevel;
            ViewBag.Content = Content;
            return View(model);
        }

        [AjaxOnly]
        public ActionResult _GetAvailableContentTypes()
        {
            Database db = new Database();
            List<ContentType> contentTypes = db.GetAvailableContentTypes();
            return View(contentTypes);
        }

        [ChildActionOnly]
        public ActionResult _Content(String Name, String Description, String Class)
        {
            ContentModel model = new ContentModel(Name, Description, Class);
            return View(model);
        }

        /// <summary>
        ///     Get Dem Cookies NOM NOM
        /// </summary>
        /// <returns></returns>
        private Profile GetProfile()
        {
            // Attempt to retrieve your cookie
            HttpCookie cookie = Request.Cookies.Get(SESSION.PROFILE);
            Profile model = null;

            // Check if the cookie exists
            if (cookie != null && model == null)
            {
                // It exists, so use it's value in a query via cookie.Value
                model = new Profile(cookie.Values["Username"],
                    cookie.Values["Class"],
                    cookie.Values["Platform"],
                    int.Parse(cookie.Values["LightLevel"]),
                    Boolean.Parse(cookie.Values["HasMic"]),
                    Boolean.Parse(cookie.Values["RequireMic"]));

                //Don't know if this works
                cookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(cookie);
                Session.Add(SESSION.PROFILE, model);
            }

            return model;
        }
    }
}