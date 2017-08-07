using System.Collections.Generic;
using BungieDestiny.Responses;
using RestSharp;

namespace BungieDestiny
{
    [Route("https://www.bungie.net/platform/Destiny")]
    public class DestinyService : BungieService
    {
        public DestinyService(string apiKey) : base(apiKey)
        {
        }

        /// <summary>
        /// Returns a list of players by username and platform.
        /// </summary>
        /// <remarks>
        /// http://bungienetplatform.wikia.com/wiki/SearchDestinyPlayer
        /// </remarks>
        [Route("/SearchDestinyPlayer/{membershipType}/{displayName}", Method.GET)]
        public SearchPlayersResponse SearchPlayers(MembershipType membershipType, string displayName)
        {
            var model = new
            {
                membershipType = (int)membershipType,
                displayName
            };

            return Request<SearchPlayersResponse>(model);
        }

        [Route("/Advisors/V2/", Method.GET)]
        public GetAdvisorsResponse GetAdvisors()
        {
            var model = new
            {
            };

            return Request<GetAdvisorsResponse>(model);
        }
    }
}
