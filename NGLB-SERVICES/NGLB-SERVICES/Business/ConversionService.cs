using Bungie;

namespace NGLB_SERVICES.Business
{
    /// <summary>
    ///     Converts common Conversions
    /// </summary>
    public static class ConversionService
    {
        /// <summary>
        ///     Returns Membership Type for Containers
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        public static MembershipType GetMembershipType(string platform)
        {
            //Variable
            MembershipType membership = MembershipType.None;

            switch(platform.ToLower())
            {
                case "xbox": membership = MembershipType.Xbox;
                    break;

                case "psn": membership = MembershipType.Psn;
                    break;

                case "all":
                    membership = MembershipType.All;
                    break;

                case "bungienext":
                    membership = MembershipType.BungieNext;
                    break;

                case "demon":
                    membership = MembershipType.Demon;
                    break;

                case "none":
                    membership = MembershipType.None;
                    break;
            }

            return membership;
        }

        /// <summary>
        ///     Returns Character Class for Containers
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public static CharacterClass GetCharacterClass(int classType)
        {
            //Variables
            CharacterClass result = CharacterClass.Unknown;

            switch(classType)
            {
                case 0: result = CharacterClass.Titan;
                    break;

                case 1:
                    result = CharacterClass.Hunter;
                    break;

                case 2:
                    result = CharacterClass.Warlock;
                    break;

                case 3:
                    result = CharacterClass.Unknown;
                    break;
            }

            return result;
        }

        /// <summary>
        ///     Converts to Gender Type
        /// </summary>
        /// <param name="genderType"></param>
        /// <returns></returns>
        public static GenderType GetGenderType(int genderType)
        {
            //Variables
            GenderType gender = GenderType.Female;

            switch(genderType)
            {
                case 0: gender = GenderType.Male;
                    break;

                case 1: gender = GenderType.Female;
                    break;
            }

            return gender;
        }
    }
}