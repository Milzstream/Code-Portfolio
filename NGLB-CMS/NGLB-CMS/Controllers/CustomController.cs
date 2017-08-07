using NGLB_CMS.Business;
using NGLB_CMS.Business.Containers;
using System.Threading.Tasks;
using System.Web.Mvc;
using NGLB_CMS.Models;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace NGLB_CMS.Controllers
{
    public class CustomController : RenderMvcController
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult GroupFinder(RenderModel model, bool? deleteCookie = false)
        {
            //If cookie exists and this wasn't intentional redirect to character selection
            if (deleteCookie.HasValue && deleteCookie.Value)
            {
                //Delete Cookie if Exists
                Cookie.DeleteCookie(System.Web.HttpContext.Current.Response);

                //Return search page
                return CurrentTemplate(model);
            }
            else
            {
                return Redirect("/services/character-selection/");
            }
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public async Task<ActionResult> CharacterSelection(RenderModel model, string membershipId = "", string platform = "")
        {
            //Variables
            Cookie cookie = Cookie.GetCookie(System.Web.HttpContext.Current.Request);
            GetCharactersModel getCharactersModel = new GetCharactersModel(model.Content);
            ProfilePreferences settings = new ProfilePreferences();

            //If membership / platform null 
            if (cookie == null && (string.IsNullOrWhiteSpace(membershipId) || string.IsNullOrWhiteSpace(platform)))
            {
                return Redirect("/services/group-finder?deleteCookie=true");
            }

            //If cookie is null
            if (cookie == null)
            {
                cookie = new Cookie();
                cookie.CharacterID = "";
                cookie.HasMic = false;
                cookie.MembershipID = membershipId;
                cookie.Platform = platform.ToLower();
                cookie.RequireMic = false;
                cookie.SubPlatform = 2;

                //Get/Set Model
                getCharactersModel.Characters = await BungieServices.GetCharacters(membershipId, platform);
            }
            else
            {
                getCharactersModel.Characters = await BungieServices.GetCharacters(cookie.MembershipID, cookie.Platform);
            }

            if (getCharactersModel.Characters == null || getCharactersModel.Characters.Count == 0)
            {
                return Redirect("/services/group-finder?deleteCookie=true");
            }

            //Set Preferences
            settings.HasMic = cookie.HasMic;
            settings.RequireMic = cookie.RequireMic;
            settings.SubPlatform = cookie.SubPlatform;
            settings.CharacterId = cookie.CharacterID;
            settings.PlatformPassThrough = cookie.Platform.ToLower();
            settings.MembershipidPassThrough = cookie.MembershipID;

            //Add to Model
            getCharactersModel.Settings = settings;

            return CurrentTemplate(getCharactersModel);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public async Task<ActionResult> ContentSelection(RenderModel model, string characterId, int? subPlatform, bool? hasMic, bool? requireMic)
        {
            //Variables
            Cookie cookie = Cookie.GetCookie(System.Web.HttpContext.Current.Request);
            DailyWeeklyFinderContentModel dailyWeeklyFinderContentModel = new DailyWeeklyFinderContentModel(model.Content);
            ProfilePreferences settings = new ProfilePreferences();

            //If membership / platform null 
            if (cookie == null &&
                (string.IsNullOrWhiteSpace(subPlatform.ToString()) || string.IsNullOrWhiteSpace(hasMic.ToString()) ||
                 string.IsNullOrWhiteSpace(requireMic.ToString()) || string.IsNullOrWhiteSpace(characterId)))
            {
                return Redirect("/services/character-selection/");
            }
            else if(cookie == null)
            {
                cookie = new Cookie();
            }

                //Set Preferences / Cookie
                cookie.HasMic = hasMic.GetValueOrDefault();
                cookie.RequireMic = requireMic.GetValueOrDefault();
                cookie.SubPlatform = subPlatform.GetValueOrDefault();
                cookie.CharacterID = characterId;

                //Set Settings for Model
                settings.HasMic = cookie.HasMic;
                settings.RequireMic = cookie.RequireMic;
                settings.SubPlatform = cookie.SubPlatform;
                settings.CharacterId = cookie.CharacterID;
                settings.PlatformPassThrough = cookie.Platform.ToLower();

                //Add to Model
                dailyWeeklyFinderContentModel.Settings = settings;
                dailyWeeklyFinderContentModel.Activities = await BungieServices.GetDailyWeeklyFinderContent();

                return CurrentTemplate(dailyWeeklyFinderContentModel);
        }
    }
}