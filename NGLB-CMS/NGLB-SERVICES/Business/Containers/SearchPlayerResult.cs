using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGLB_SERVICES.Business.Containers
{   
    /// <summary>
    ///     Player Object
    /// </summary>
    public struct SearchPlayerResult
    {
        /// <summary>
        ///     Display Name (Gamertag)
        /// </summary>
        public String PlayerName { get; set; }
        
        /// <summary>
        ///     Platform (xbox,psn)
        /// </summary>
        public String Platform { get; set; }

        /// <summary>
        ///     Path to Player Platform Icon
        /// </summary>
        public String IconImg { get; set; }

        /// <summary>
        ///     The unique ID (numbers) that represent this player
        /// </summary>
        public String MembershipId { get; set; }
    }
}