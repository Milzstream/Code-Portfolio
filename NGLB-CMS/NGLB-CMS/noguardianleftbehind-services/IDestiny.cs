﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using NGLBCMS.Models;

namespace NGLBCMS
{
    public partial interface IDestiny
    {
        /// <param name='apiKey'>
        /// Required. Bungie Provided API KEY
        /// </param>
        /// <param name='membershipId'>
        /// Required. This is a unique number associated with a player's account
        /// </param>
        /// <param name='platform'>
        /// Required. This is the platform the player is on (xbox/psn)
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<IList<CharacterSelection>>> GetCharactersWithOperationResponseAsync(string apiKey, string membershipId, string platform, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='apiKey'>
        /// Required. Bungie Provided API KEY
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<DailyWeeklyFinderContentResult>> GetDailyWeeklyFinderContentWithOperationResponseAsync(string apiKey, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='apiKey'>
        /// Required. Bungie Provided API KEY
        /// </param>
        /// <param name='player'>
        /// Required. Gamertag (platform independent)
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<IList<SearchPlayerResult>>> SearchPlayerWithOperationResponseAsync(string apiKey, string player, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}