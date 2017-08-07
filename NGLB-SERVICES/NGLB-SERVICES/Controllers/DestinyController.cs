using NGLB_SERVICES.Business;
using NGLB_SERVICES.Business.Containers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using Bungie.Models;

namespace NGLB_SERVICES.Controllers
{
    /// <summary>
    ///     This controller contains all of the Services that connect and pull data from Bungie.net
    /// </summary>
    [Description("This controller contains all of the Services that connect and pull data from Bungie.net")]
    public class DestinyController : ApiController
    {
        /// <summary>
        /// This returns a list of Players (with basic info) that match the player name
        /// </summary>
        /// <param name="apiKey">Bungie Provided API KEY</param>
        /// <param name="player">Gamertag (platform independent)</param>
        /// <returns></returns>
        [Route("destiny/{apiKey}/searchplayer/{player}")]
        [ResponseType(typeof(List<UserInfo>))]
        [HttpGet]
        public async Task<JsonResult<List<UserInfo>>> SearchPlayer(string apiKey, string player)
        {
            try //Try to block errors from viewers
            {
                //Variables
                Destiny service = new Destiny(apiKey);

                List<UserInfo> list = await service.PlayerSearchListAsync(player);

                return Json(list);

            }
            catch (Exception)
            {
                throw new Exception("Something went wrong.. We Logged it and will fix it. Try again later!");
            }
        }

        /// <summary>
        /// This returns an object that contains a list of all the Daily and Weekly Activities
        /// </summary>
        /// <param name="apiKey">Bungie Provided API KEY</param>
        /// <returns></returns>
        [Route("destiny/{apiKey}/getdailyweeklycontent")]
        [ResponseType(typeof(DailyWeeklyFinderContentResult))]
        [HttpGet]
        public async Task<JsonResult<DailyWeeklyFinderContentResult>> GetDailyWeeklyFinderContent(string apiKey)
        {
            try //Try to block errors from viewers
            {
                //Variables
                Destiny service = new Destiny(apiKey);

                DailyWeeklyFinderContentResult result = await service.GetDailyWeeklyFinderContentAsync();

                return Json(result);

            }
            catch (Exception)
            {
                throw new Exception("Something went wrong.. We Logged it and will fix it. Try again later!");
            }
        }

        /// <summary>
        ///     This returns a list of characters that match a specific player
        /// </summary>
        /// <param name="apiKey">Bungie Provided API KEY</param>
        /// <param name="membershipId">This is a unique number associated with a player's account</param>
        /// <param name="platform">This is the platform the player is on (xbox/psn)</param>
        /// <returns></returns>
        [Route("destiny/{apiKey}/getcharacters/{membershipId}/{platform}")]
        [ResponseType(typeof(List<CharacterSelection>))]
        [HttpGet]
        public async Task<JsonResult<List<CharacterSelection>>> GetCharacters(string apiKey, string membershipId, string platform)
        {
            try //Try to block errors from viewers
            {
                //Variables
                Destiny service = new Destiny(apiKey);

                List<CharacterSelection> list = await service.GetCharactersAsync(platform, membershipId);

                return Json(list);

            }
            catch (Exception)
            {
                throw new Exception("Something went wrong.. We Logged it and will fix it. Try again later!");
            }
        }
    }
}