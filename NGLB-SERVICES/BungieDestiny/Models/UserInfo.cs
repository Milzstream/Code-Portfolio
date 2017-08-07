namespace BungieDestiny.Models
{
    /// <summary>
    ///     Represents the returned values from searching for a Destiny Account
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        ///     Platform Icon Path
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        ///     Membership Type Number
        /// </summary>
        public MembershipType MembershipType { get; set; }

        /// <summary>
        ///     Membership Id Number
        /// </summary>
        public long MembershipId { get; set; }

        /// <summary>
        ///     Destiny Account Display Name (Gamertag)
        /// </summary>
        public string DisplayName { get; set; }
    }
}
