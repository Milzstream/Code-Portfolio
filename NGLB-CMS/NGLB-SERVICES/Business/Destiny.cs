using System.Collections.Generic;
using System.Linq;
using Bungie;
using System.Threading.Tasks;
using Bungie.Models;
using Bungie.Responses;
using NGLB_SERVICES.Business.Containers;

namespace NGLB_SERVICES.Business
{
    /// <summary>
    ///     Destiny Business Class
    /// </summary>
    public class Destiny
    {
        //variables
        private DestinyService service;

        /// <summary>
        ///     Set the API Key for the Destiny Service
        /// </summary>
        /// <param name="apiKey"></param>
        public Destiny(string apiKey)
        {
            service = new DestinyService(apiKey);
        }

        public async void Activities(string platform, string membershipId, string characterId)
        {
            GetActivitiesResponse pveActivitiesResponse = await service.GetActivities(ConversionService.GetMembershipType(platform),
                long.Parse(membershipId), long.Parse(characterId), ActivityMode.AllPvE, definitions: true);
            GetActivitiesResponse pvpActivitiesResponse = await service.GetActivities(ConversionService.GetMembershipType(platform),
                long.Parse(membershipId), long.Parse(characterId), ActivityMode.AllPvP, definitions: true);

            foreach (var test in pveActivitiesResponse.Definitions.Activities)
            {
                //test.Value.
            }

            
        }

        /// <summary>
        ///     Gets the current Weekly/Daily Content
        /// </summary>
        /// <returns></returns>
        public async Task<DailyWeeklyFinderContentResult> GetDailyWeeklyFinderContentAsync()
        {
            //Variables
            DailyWeeklyFinderContentResult model = new DailyWeeklyFinderContentResult();
            Bungie.Definitions.Activity activity;
            Bungie.Definitions.ActivityType activityType;

            //Get Response
            GetAdvisorsResponse response = await service.GetAdvisors(definitions: true);

            ////////    Daily Mission ----------------------------------------------------------------------------------------------->
            Containers.Activity dailyMission = new Containers.Activity();
            Containers.ActivityType dailyMissionType = new Containers.ActivityType();
            List<Skull> dailyMissionSkulls = new List<Skull>();

            //Get Activity and Activity Type
            response.Definitions.Activities.TryGetValue(response.Advisors.DailyChapterHashes.FirstOrDefault(), out activity);
            response.Definitions.ActivityTypes.TryGetValue(activity.ActivityTypeHash, out activityType);

            //Set Temp Activity Type Values
            dailyMissionType.ActivityIdentifier = activityType.Identifier;
            dailyMissionType.ActivityTypeID = activityType.ActivityTypeHash.ToString();
            dailyMissionType.Description = activityType.ActivityTypeDescription;
            dailyMissionType.IconPath = "https://www.bungie.net" + activityType.ActiveBackgroundVirtualPath;
            dailyMissionType.Name = "Daily Story";

            //Set Temp Activity Values
            dailyMission.ActivityID = activity.ActivityHash.ToString();
            dailyMission.Description = activity.ActivityDescription;
            dailyMission.IconPath = "https://www.bungie.net" + response.Advisors.DailyChapter.IconPath;
            dailyMission.Level = activity.ActivityLevel;
            dailyMission.MaxParty = activity.MaxParty;
            dailyMission.MaxPlayers = activity.MaxPlayers;
            dailyMission.MinParty = activity.MinParty;
            dailyMission.Name = activity.ActivityName;
            dailyMission.PageBannerImagePath = "https://www.bungie.net" + activity.PgcrImage;
            dailyMission.Tier = activity.Tier;
            dailyMission.ResetTime = response.Advisors.DailyChapter.ExpirationDate;
            dailyMission.ActivityType = dailyMissionType; // ACTIVTYTYPE TEMP
            dailyMission.Modifiers = dailyMissionSkulls; //SKULL TEMP (no skulls here)

            //Add to model
            model.DailyMission = dailyMission;

            ////////    Daily Crucible ----------------------------------------------------------------------------------------------->
            Containers.Activity dailyCrucible = new Containers.Activity();
            Containers.ActivityType dailyCrucibleType = new Containers.ActivityType();
            List<Skull> dailyCrucibleSkulls = new List<Skull>();

            //Get Activity and Activity Type
            response.Definitions.Activities.TryGetValue(response.Advisors.DailyCrucibleHash, out activity);
            response.Definitions.ActivityTypes.TryGetValue(activity.ActivityTypeHash, out activityType);

            //Set Temp Activity Type Values
            dailyCrucibleType.ActivityIdentifier = activityType.Identifier;
            dailyCrucibleType.ActivityTypeID = activityType.ActivityTypeHash.ToString();
            dailyCrucibleType.Description = activityType.ActivityTypeDescription;
            dailyCrucibleType.IconPath = "https://www.bungie.net" + activityType.ActiveBackgroundVirtualPath;
            dailyCrucibleType.Name = "Daily Crucible";

            //Set Temp Activity Values
            dailyCrucible.ActivityID = activity.ActivityHash.ToString();
            dailyCrucible.Description = activity.ActivityDescription;
            dailyCrucible.IconPath = "https://www.bungie.net" + response.Advisors.DailyCrucible.IconPath;
            dailyCrucible.Level = activity.ActivityLevel;
            dailyCrucible.MaxParty = activity.MaxParty;
            dailyCrucible.MaxPlayers = activity.MaxPlayers;
            dailyCrucible.MinParty = activity.MinParty;
            dailyCrucible.Name = activity.ActivityName;
            dailyCrucible.PageBannerImagePath = "https://www.bungie.net" + activity.PgcrImage;
            dailyCrucible.Tier = activity.Tier;
            dailyCrucible.ResetTime = response.Advisors.DailyCrucible.ExpirationDate;
            dailyCrucible.ActivityType = dailyCrucibleType; // ACTIVTYTYPE TEMP
            dailyCrucible.Modifiers = dailyCrucibleSkulls; //SKULL TEMP (no skulls here)

            //Add to model
            model.DailyCrucible = dailyCrucible;

            ////////    Heroic Strike ----------------------------------------------------------------------------------------------->
            Containers.Activity heroicStrike = new Containers.Activity();
            Containers.ActivityType heroicStrikeType = new Containers.ActivityType();
            List<Skull> heroicStrikeSkulls = new List<Skull>();

            //Get Activity and Activity Type
            response.Definitions.Activities.TryGetValue(response.Advisors.HeroicStrikeHashes.FirstOrDefault(), out activity);
            response.Definitions.ActivityTypes.TryGetValue(activity.ActivityTypeHash, out activityType);

            //Set Temp Activity Type Values
            heroicStrikeType.ActivityIdentifier = activityType.Identifier;
            heroicStrikeType.ActivityTypeID = activityType.ActivityTypeHash.ToString();
            heroicStrikeType.Description = activityType.ActivityTypeDescription;
            heroicStrikeType.IconPath = "https://www.bungie.net" + activityType.ActiveBackgroundVirtualPath;
            heroicStrikeType.Name = "Weekly Heroic Strikes";
         
            //Set Temp Activity Values
            heroicStrike.ActivityID = activity.ActivityHash.ToString();
            heroicStrike.Description = activity.ActivityDescription;
            heroicStrike.IconPath = "https://www.bungie.net" + activity.Icon;
            heroicStrike.Level = activity.ActivityLevel;
            heroicStrike.MaxParty = activity.MaxParty;
            heroicStrike.MaxPlayers = activity.MaxPlayers;
            heroicStrike.MinParty = activity.MinParty;
            heroicStrike.Name = activity.ActivityName;
            heroicStrike.PageBannerImagePath = "https://www.bungie.net" + activity.PgcrImage;
            heroicStrike.Tier = activity.Tier;
            heroicStrike.ResetTime = response.Advisors.HeroicStrikeResetDate;
            heroicStrike.ActivityType = heroicStrikeType; // ACTIVTYTYPE TEMP
            heroicStrike.Modifiers = heroicStrikeSkulls; //SKULL TEMP (no skulls here)

            //Add to model
            model.HeroicStrike = heroicStrike;

            ////////    Weekly Crucible ----------------------------------------------------------------------------------------------->
            Containers.Activity weeklyCrucible = new Containers.Activity();
            Containers.ActivityType weeklyCrucibleType = new Containers.ActivityType();
            List<Skull> weeklyCrucibleSkulls = new List<Skull>();

            //Oddly need bundle for this
            Bungie.Definitions.ActivityBundle _activity_bundle = null;

            //Get Activity and Activity Type
            response.Definitions.ActivityBundles.TryGetValue(response.Advisors.WeeklyCrucible.First().ActivityBundleHash, out _activity_bundle);
            //response.Definitions.Activities.TryGetValue(response.Advisors.WeeklyCrucible.FirstOrDefault(), out activity);
            response.Definitions.ActivityTypes.TryGetValue(_activity_bundle.ActivityTypeHash, out activityType);

            //Set Temp Activity Type Values
            weeklyCrucibleType.ActivityIdentifier = activityType.Identifier;
            weeklyCrucibleType.ActivityTypeID = activityType.ActivityTypeHash.ToString();
            weeklyCrucibleType.Description = activityType.ActivityTypeDescription;
            weeklyCrucibleType.IconPath = "https://www.bungie.net" + activityType.ActiveBackgroundVirtualPath;
            weeklyCrucibleType.Name = "Weekly Crucible";

            //Set Temp Activity Values
            weeklyCrucible.ActivityID = _activity_bundle.ActivityHashes.First().ToString();
            weeklyCrucible.Description = _activity_bundle.ActivityDescription;
            weeklyCrucible.IconPath = "https://www.bungie.net" + activityType.Icon;
            weeklyCrucible.Level = 1;
            weeklyCrucible.MaxParty = 6;
            weeklyCrucible.MaxPlayers = 6;
            weeklyCrucible.MinParty = 1;
            weeklyCrucible.Name = _activity_bundle.ActivityName;
            weeklyCrucible.PageBannerImagePath = dailyCrucible.PageBannerImagePath;
            weeklyCrucible.Tier = activity.Tier;
            weeklyCrucible.ResetTime = response.Advisors.WeeklyCrucible.First().ExpirationDate;
            weeklyCrucible.ActivityType = weeklyCrucibleType; // ACTIVTYTYPE TEMP
            weeklyCrucible.Modifiers = weeklyCrucibleSkulls; //SKULL TEMP (no skulls here)

            //Add to model
            model.WeeklyCrucible = weeklyCrucible;

            ////////    Weekly Nightfall ----------------------------------------------------------------------------------------------->
            Containers.Activity weeklyNightfall = new Containers.Activity();
            Containers.ActivityType weeklyNightfallType = new Containers.ActivityType();
            List<Skull> weeklyNightfallSkulls = new List<Skull>();

            //Get Activity and Activity Type
            response.Definitions.Activities.TryGetValue(response.Advisors.Nightfall.SpecificActivityHash, out activity);
            response.Definitions.ActivityTypes.TryGetValue(activity.ActivityTypeHash, out activityType);

            //Set Temp Activity Type Values
            weeklyNightfallType.ActivityIdentifier = activityType.Identifier;
            weeklyNightfallType.ActivityTypeID = activityType.ActivityTypeHash.ToString();
            weeklyNightfallType.Description = activityType.ActivityTypeDescription;
            weeklyNightfallType.IconPath = "https://www.bungie.net" + activityType.ActiveBackgroundVirtualPath;
            weeklyNightfallType.Name = "Weekly Nightfall";

            //var activitys = await service.GetDefinition(DefinitionType.Activity, response.Advisors.NightfallActivityHash, definitions: true);
            var skulls = response.Definitions.Activities[response.Advisors.NightfallActivityHash].Skull;

            //Set Temp Modifiers
            foreach (int skull in (response.Advisors.Nightfall.Tiers.First()).SkullIndexes)
            {
                //Temp Vars
                Skull temp = new Skull();
                Bungie.Definitions.ScriptedSkull _script_skull = null;

                //try and extract
                response.Definitions.ScriptedSkulls.TryGetValue(skull, out _script_skull);

                if (_script_skull != null)
                {
                    //Set temp
                    temp.Description = _script_skull.Description;
                    temp.IconPath = "https://www.bungie.net" + _script_skull.IconPath;
                    temp.Name = _script_skull.SkullName;
                    temp.SkullID = _script_skull.SkullHash.ToString();
                    temp.SkullIdentifier = _script_skull.Identifier;

                    //Add
                    weeklyNightfallSkulls.Add(temp);
                }
            }

            //Set Temp Activity Values
            weeklyNightfall.ActivityID = activity.ActivityHash.ToString();
            weeklyNightfall.Description = activity.ActivityDescription;
            weeklyNightfall.IconPath = "https://www.bungie.net" + activity.Icon;
            weeklyNightfall.Level = activity.ActivityLevel;
            weeklyNightfall.MaxParty = activity.MaxParty;
            weeklyNightfall.MaxPlayers = activity.MaxPlayers;
            weeklyNightfall.MinParty = activity.MinParty;
            weeklyNightfall.Name = activity.ActivityName;
            weeklyNightfall.PageBannerImagePath = "https://www.bungie.net" + activity.PgcrImage;
            weeklyNightfall.Tier = activity.Tier;
            weeklyNightfall.ResetTime = response.Advisors.NightfallResetDate;
            weeklyNightfall.ActivityType = weeklyNightfallType; // ACTIVTYTYPE TEMP
            weeklyNightfall.Modifiers = weeklyNightfallSkulls; //SKULL TEMP (no skulls here)

            //Add to model
            model.WeeklyNightfall = weeklyNightfall;

            return model;
        }

        /// <summary>
        ///     This returns the Gamertag associated with all Platforms that match the inputed Gamertag name (Exact Gamertag) 
        /// </summary>
        public async Task<List<SearchPlayerResult>> PlayerSearchListAsync(string player)
        {
            //variables
            List<SearchPlayerResult> list = new List<SearchPlayerResult>();
            SearchPlayersResponse response =  null;

            //Set/Get Response
            response = await service.SearchPlayers(MembershipType.All, player);

            //Loop through returned
            foreach(UserInfo user in response)
            {
                list.Add(new SearchPlayerResult() { PlayerName = user.DisplayName, Platform = user.MembershipType.ToString(), IconImg = user.MembershipType == MembershipType.Psn ? "/media/custom/icon_psn.png" : "/media/custom/icon_xbl.png", MembershipId = user.MembershipId.ToString() });
            }

            return list;
        }

        /// <summary>
        ///     Returns a list of characters based on the player's membershipID and Platform
        /// </summary>
        /// <param name="platform">platform (xbox, psn)</param>
        /// <param name="membershipid">number that references player account membership</param>
        /// <returns>List of Characters for matching Player</returns>
        public async Task<List<CharacterSelection>> GetCharactersAsync(string platform, string membershipid)
        {
            //Variables
            MembershipType _Platform = ConversionService.GetMembershipType(platform);
            long _MembershipID = long.Parse(membershipid);
            List<CharacterSelection> result = new List<CharacterSelection>();

            //Set/Get Response
            GetAccountSummaryResponse response = await service.GetAccountSummary(_Platform, _MembershipID);

            //Loop through Characters
            foreach(Character character in response.AccountSummary.Characters)
            {
                //Temp Var
                CharacterSelection temp_character = new CharacterSelection();

                //Additional Character Info
                GetCharacterResponse char_response = await service.GetCharacter(_Platform, _MembershipID, long.Parse(character.CharacterBase.CharacterId));
                GetDefinitionResponse def_response = await service.GetDefinition(DefinitionType.Race, character.CharacterBase.RaceHash);
                //Set Values
                temp_character.Class = ConversionService.GetCharacterClass(character.CharacterBase.ClassType).ToString();
                temp_character.EmblemBackgroundPath = "https://www.bungie.net" + char_response.Character.BackgroundPath;
                temp_character.CharacterID = character.CharacterBase.CharacterId;
                temp_character.EmblemPath = "https://www.bungie.net" + char_response.Character.EmblemPath;
                temp_character.Gender = ConversionService.GetGenderType(character.CharacterBase.GenderType).ToString();
                temp_character.Level = char_response.Character.BaseCharacterLevel;
                temp_character.LightLevel = character.CharacterBase.PowerLevel;
                temp_character.Race = def_response.Definition.Race.RaceName;

                //Add to List
                result.Add(temp_character);
            }

            return result;
        }
    }
}