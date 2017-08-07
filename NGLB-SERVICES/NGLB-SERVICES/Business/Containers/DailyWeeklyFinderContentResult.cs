using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bungie.Definitions;

namespace NGLB_SERVICES.Business.Containers
{
    /// <summary>
    ///     List of Daily and Weekly Group Activities
    /// </summary>
    public struct DailyWeeklyFinderContentResult
    {
        /// <summary>
        ///     Daily Story Mission Activity Object
        /// </summary>
        public Activity DailyMission { get; set; }

        /// <summary>
        ///     Daily PVP Crucible Activity Object
        /// </summary>
        public Activity DailyCrucible { get; set; }

        /// <summary>
        ///     Weekly Heroic Strikes Activity Object 
        /// </summary>
        public Activity HeroicStrike { get; set; }

        /// <summary>
        ///     Weekly Nightfall Strike Activity Object
        /// </summary>
        public Activity WeeklyNightfall { get; set; }

        /// <summary>
        ///     Weekly PVP Crucible Activity Object
        /// </summary>
        public Activity WeeklyCrucible { get; set; }
    }

    /// <summary>
    ///     Individual Group Activity (raid, mission, strike)
    /// </summary>
    public struct Activity
    {
        /// <summary>
        ///     Activity Name (Vanguard Heroic Strikes, Nightfall, etc)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Activity Description (Launches a random Heroic strike, etc)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Activity Unique ID (number/hash)
        /// </summary>
        public string ActivityID { get; set; }

        /// <summary>
        ///     Activity Level (41, etc)
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Activity Type ID (number/hash)
        /// </summary>
        public ActivityType ActivityType { get; set; }

        /// <summary>
        ///     Absolute Image Path of Activity Icon
        /// </summary>
        public string IconPath { get; set; }

        ///// <summary>
        /////     Absolute Image Path of Activity Release Icon
        ///// </summary>
        //public String ReleaseIconPath { get; set; }

        /// <summary>
        ///     Absolute Image Path of Activity Page Banner Image
        /// </summary>
        public string PageBannerImagePath { get; set; }

        /// <summary>
        ///     Maximum Players in Activity
        /// </summary>
        public int MaxPlayers { get; set; }

        /// <summary>
        ///     Max Player Party Size
        /// </summary>
        public int MaxParty { get; set; }

        /// <summary>
        ///     Minimum Party Size
        /// </summary>
        public int MinParty { get; set; }

        /// <summary>
        ///     The Content Tier (Max Level Daily/Weekly/Level 30 content, etc)
        /// </summary>
        public int Tier { get; set; }

        /// <summary>
        ///     A list of objects that reprsent the Skull Modifiers
        /// </summary>
        public List<ActivitySkull> Modifiers { get; set; }

        /// <summary>
        ///     This is the DateTime that the Activity will Reset At
        /// </summary>
        public DateTime ResetTime { get; set; }

    }

    /// <summary>
    ///     Type of Activity (Raid, Strike, Bounty, Cruciable)
    /// </summary>
    public struct ActivityType
    {
        /// <summary>
        ///     Unique ID (number, hash) that represents this Activity Type
        /// </summary>
        public string ActivityTypeID { get; set; }

        /// <summary>
        ///     Name of Activity Type (Strike, Raid, Bounty, etc)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Activity Type Description (Join a fireteam of three and face the most feared minions of the Darkness.,etc)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Activity Type Absolute Image Path (Strike Icon, Raid Icon, etc)
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        ///     Unique Identifier that describes specific activity type (ACTIVITY_TYPE_NIGHTFALL, etc)
        /// </summary>
        public string ActivityIdentifier { get; set; }
    }

    /// <summary>
    ///     This is an Object that reprsents the difficulty modifiers known as "skulls"
    /// </summary>
    public struct Skull
    {
        /// <summary>
        ///     Name of Skull (trickle, etc)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Description of Skull (ability recharge slower, etc)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Absolute Image Path to Skull Icon
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        ///     Unique String Key that reprsents Skull Identifier (SKULL_TRICKLE)
        /// </summary>
        public string SkullIdentifier { get; set; }

        /// <summary>
        ///     The Skull's Unique Identifier (number, hash)
        /// </summary>
        public string SkullID { get; set; }
    }
}