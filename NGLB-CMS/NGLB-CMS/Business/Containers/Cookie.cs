using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGLB_CMS.Business.Containers
{
    public class Cookie
    {
        public Cookie() { }

        public string Platform { get; set; }
        public int SubPlatform { get; set; }
        public string MembershipID { get; set; }
        public bool HasMic { get; set; }
        public bool RequireMic { get; set; }
        public string CharacterID { get; set; }

        public static readonly string COOKIE_NAME = "nglbcookie";

        public static Cookie GetCookie(HttpRequest Request)
        {
            // Attempt to retrieve your cookie
            HttpCookie cookie = Request.Cookies[Cookie.COOKIE_NAME];
            Cookie model = null;

            // Check if the cookie exists
            if (cookie != null)
            {
                // It exists, so use it's value in a query via cookie.Value
                model = new Cookie();

                //Set Values from Cookie
                model.MembershipID = cookie["MembershipID"];
                model.CharacterID = cookie["CharacterID"];
                model.Platform = cookie["Platform"];

                //Temp for nonString Values
                int _subplatform = 2;
                bool _hasmic = false, _requiremic = false;

                //Trys
                int.TryParse(cookie["SubPlatform"], out _subplatform);
                bool.TryParse(cookie["HasMic"], out _hasmic);
                bool.TryParse(cookie["RequireMic"], out _requiremic);

                //Set oddballs
                model.SubPlatform = _subplatform;
                model.HasMic = _hasmic;
                model.RequireMic = _requiremic;
            }

            return model;
        }

        public static void SetCookie(Cookie model, HttpResponse Response)
        {
            //Variables
            HttpCookie cookie = new HttpCookie(Cookie.COOKIE_NAME);

                //Set Cookie Values
                cookie["MembershipID"] = model.MembershipID;
                cookie["CharacterID"] = model.CharacterID;
                cookie["Platform"] = model.Platform;
                cookie["SubPlatform"] = model.SubPlatform.ToString();
                cookie["HasMic"] = model.HasMic.ToString();
                cookie["RequireMic"] = model.RequireMic.ToString();

                //Update Cookie
                cookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(cookie);
       }

        public static void DeleteCookie(HttpResponse Response)
        {
            HttpCookie c = new HttpCookie(Cookie.COOKIE_NAME);
            c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c);
        }
    }
}