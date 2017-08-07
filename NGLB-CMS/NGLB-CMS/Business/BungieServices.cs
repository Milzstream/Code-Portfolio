using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using NGLBCMS;
using NGLBCMS.Models;

namespace NGLB_CMS.Business
{
    public static class BungieServices
    {
        //Variables
        private static readonly string ApiKey = ConfigurationManager.AppSettings["BungieAPI"];
        private static readonly Destiny Service = new Destiny(new NoguardianleftbehindServices());

        /// <summary>
        ///     Calls the RestAPI and returns A List of SearchPlayerResult
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static async Task<List<SearchPlayerResult>> SearchPlayers(string player)
        {
            //Execute Request
            var result = await Service.SearchPlayerWithOperationResponseAsync(ApiKey, player);

            //Check Null
            return result?.Body.ToList() ?? new List<SearchPlayerResult>();
        }

        /// <summary>
        ///     Calls the RestAPI and returns A DailyWeeklyFinderContentResult
        /// </summary>
        /// <returns></returns>
        public static async Task<DailyWeeklyFinderContentResult> GetDailyWeeklyFinderContent()
        {
            //Execute Request
            var result = await Service.GetDailyWeeklyFinderContentWithOperationResponseAsync(ApiKey);

            //Check Null
            return result?.Body ?? new DailyWeeklyFinderContentResult();
        }

        /// <summary>
        ///     Calls the RestAPI and returns A List of CharacterSelection
        /// </summary>
        /// <param name="membershipId"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public static async Task<List<CharacterSelection>> GetCharacters(string membershipId, string platform)
        {
            //Execute Request
            var result = await Service.GetCharactersWithOperationResponseAsync(ApiKey, membershipId, platform);

            //Check Null
            return result?.Body.ToList() ?? new List<CharacterSelection>();
        }

    }
}