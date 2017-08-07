using NGLB_CMS.Business;
using NGLB_CMS.Business.Containers;
using NGLBCMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NGLB_CMS.Controllers
{
    public class GroupFinderController : Umbraco.Web.Mvc.SurfaceController
    {
        [AjaxOnly]
        public async Task<ActionResult> SearchPlayers(string id)
        {
            //Variables
            List<SearchPlayerResult> list = await BungieServices.SearchPlayers(id);

            ViewBag.ReturnedPlayers = list;

            return View();
        }

        [AjaxOnly]
        public ActionResult CreateCookie(Cookie cookie)
        {
            Cookie.SetCookie(cookie, System.Web.HttpContext.Current.Response);
            return Json(new { Success = true });
        }
    }
}