using System.Collections.Generic;
using System.Linq;
using Bungie;
using System.Threading.Tasks;
using Bungie.Definitions;
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

        //public async void Activities(string platform, string membershipId, string characterId)
        //{

        //}



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

            //Get Activity and Activity Type
            response.Definitions.Activities.TryGetValue(response.Advisors.DailyChapterHashes.FirstOrDefault(), out activity);
            if (activity != null)
            {
                response.Definitions.ActivityTypes.TryGetValue(activity.ActivityTypeHash, out activityType);

                //Set Temp Activity Type Values
                if (activityType != null)
                {
                    dailyMissionType.ActivityIdentifier = activityType.Identifier;
                    dailyMissionType.ActivityTypeID = activityType.ActivityTypeHash.ToString();
                    dailyMissionType.Description = activityType.ActivityTypeDescription;
                    dailyMissionType.IconPath = "https://www.bungie.net" + activityType.ActiveBackgroundVirtualPath;
                    dailyMissionType.Name = "Daily Story";

                    if (activity.Skulls != null && activity.ActivityHash == response.Advisors.DailyChapterHashes.FirstOrDefault())
                    {
                        //Skulls
                        dailyMission.Modifiers = activity.Skulls.ToList();
                    }

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

                    //Add to model
                    model.DailyMission = dailyMission;

                    ////////    Daily Crucible ----------------------------------------------------------------------------------------------->
                    Containers.Activity dailyCrucible = new Containers.Activity();
                    Containers.ActivityType dailyCrucibleType = new Containers.ActivityType();

                    //Get Activity and Activity Type
                    response.Definitions.Activities.TryGetValue(response.Advisors.DailyCrucibleHash, out activity);
                    if (activity != null)
                    {
                        response.Definitions.ActivityTypes.TryGetValue(activity.ActivityTypeHash, out activityType);

                        //Set Temp Activity Type Values
                        if (activityType != null)
                        {
                            dailyCrucibleType.ActivityIdentifier = activityType.Identifier;
                            dailyCrucibleType.ActivityTypeID = activityType.ActivityTypeHash.ToString();
                            dailyCrucibleType.Description = activityType.ActivityTypeDescription;
                            dailyCrucibleType.IconPath = "https://www.bungie.net" + activityType.ActiveBackgroundVirtualPath;
                            dailyCrucibleType.Name = "Daily Crucible";

                            if (activity.Skulls != null && activity.ActivityHash == response.Advisors.DailyCrucibleHash)
                            {
                                //Skulls
                                dailyCrucible.Modifiers = activity.Skulls.ToList();
                            }

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

                            //Add to model
                            model.DailyCrucible = dailyCrucible;

                            ////////    Heroic Strike ----------------------------------------------------------------------------------------------->
                            Containers.Activity heroicStrike = new Containers.Activity();
                            Containers.ActivityType heroicStrikeType = new Containers.ActivityType();

                            //Get Activity and Activity Type
                            response.Definitions.Activities.TryGetValue(response.Advisors.HeroicStrikeHashes.FirstOrDefault(), out activity);
                            if (activity != null)
                            {
                                response.Definitions.ActivityTypes.TryGetValue(activity.ActivityTypeHash, out activityType);

                                //Set Temp Activity Type Values
                                if (activityType != null)
                                {
                                    heroicStrikeType.ActivityIdentifier = activityType.Identifier;
                                    heroicStrikeType.ActivityTypeID = activityType.ActivityTypeHash.ToString();
                                    heroicStrikeType.Description = activityType.ActivityTypeDescription;
                                    heroicStrikeType.IconPath = "https://www.bungie.net" + activityType.ActiveBackgroundVirtualPath;
                                    heroicStrikeType.Name = "Weekly Heroic Strikes";

                                    if (activity.Skulls != null && activity.ActivityHash == response.Advisors.HeroicStrikeHashes.FirstOrDefault())
                                    {
                                        //Skulls
                                        heroicStrike.Modifiers = activity.Skulls.ToList();
                                    }

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

                                    //Add to model
                                    model.HeroicStrike = heroicStrike;

                                    ////////    Weekly Crucible ----------------------------------------------------------------------------------------------->
                                    Containers.Activity weeklyCrucible = new Containers.Activity();
                                    Containers.ActivityType weeklyCrucibleType = new Containers.ActivityType();

                                    //Oddly need bundle for this
                                    Bungie.Definitions.ActivityBundle activityBundle;

                                    //Get Activity and Activity Type
                                    response.Definitions.ActivityBundles.TryGetValue(response.Advisors.WeeklyCrucible.First().ActivityBundleHash, out activityBundle);
                                    //response.Definitions.Activities.TryGetValue(response.Advisors.WeeklyCrucible.FirstOrDefault(), out activity);
                                    if (activityBundle != null)
                                    {
                                        response.Definitions.ActivityTypes.TryGetValue(activityBundle.ActivityTypeHash, out activityType);

                                        //Set Temp Activity Type Values
                                        if (activityType != null)
                                        {
                                            weeklyCrucibleType.ActivityIdentifier = activityType.Identifier;
                                            weeklyCrucibleType.ActivityTypeID = activityType.ActivityTypeHash.ToString();
                                            weeklyCrucibleType.Description = activityType.ActivityTypeDescription;
                                            weeklyCrucibleType.IconPath = "https://www.bungie.net" + activityType.ActiveBackgroundVirtualPath;
                                            weeklyCrucibleType.Name = "Weekly Crucible";

                                            if (activity.Skulls != null && activity.ActivityHash == response.Advisors.WeeklyCrucible.First().ActivityBundleHash)
                                            {
                                                //Skulls
                                                weeklyCrucible.Modifiers = activity.Skulls.ToList();
                                            }

                                            //Set Temp Activity Values
                                            weeklyCrucible.ActivityID = activityBundle.ActivityHashes.First().ToString();
                                            weeklyCrucible.Description = activityBundle.ActivityDescription;
                                            weeklyCrucible.IconPath = "https://www.bungie.net" + activityType.Icon;
                                        }
                                        weeklyCrucible.Level = 1;
                                        weeklyCrucible.MaxParty = 6;
                                        weeklyCrucible.MaxPlayers = 6;
                                        weeklyCrucible.MinParty = 1;
                                        weeklyCrucible.Name = activityBundle.ActivityName;
                                    }
                                    weeklyCrucible.PageBannerImagePath = dailyCrucible.PageBannerImagePath;
                                    weeklyCrucible.Tier = activity.Tier;
                                    weeklyCrucible.ResetTime = response.Advisors.WeeklyCrucible.First().ExpirationDate;
                                    weeklyCrucible.ActivityType = weeklyCrucibleType; // ACTIVTYTYPE TEMP

                                    //Add to model
                                    model.WeeklyCrucible = weeklyCrucible;

                                    ////////    Weekly Nightfall ----------------------------------------------------------------------------------------------->
                                    Containers.Activity weeklyNightfall = new Containers.Activity();
                                    Containers.ActivityType weeklyNightfallType = new Containers.ActivityType();

                                    //Get Activity and Activity Type
                                    response.Definitions.Activities.TryGetValue(response.Advisors.Nightfall.SpecificActivityHash, out activity);
                                    if (activity != null)
                                    {
                                        response.Definitions.ActivityTypes.TryGetValue(activity.ActivityTypeHash, out activityType);

                                        //Set Temp Activity Type Values
                                        if (activityType != null)
                                        {
                                            weeklyNightfallType.ActivityIdentifier = activityType.Identifier;
                                            weeklyNightfallType.ActivityTypeID = activityType.ActivityTypeHash.ToString();
                                            weeklyNightfallType.Description = activityType.ActivityTypeDescription;
                                            weeklyNightfallType.IconPath = "https://www.bungie.net" + activityType.ActiveBackgroundVirtualPath;
                                        }
                                        weeklyNightfallType.Name = "Weekly Nightfall";


                                        if (activity.Skulls != null && activity.Skulls.Length > 0 && activity.ActivityHash == response.Advisors.Nightfall.SpecificActivityHash)
                                        {
                                            //Skulls
                                            weeklyNightfall.Modifiers = activity.Skulls.ToList();
                                        }

                                        if (weeklyNightfall.Modifiers.Count == 0)
                                        {
                                            foreach (int skullId in response.Advisors.Nightfall.Tiers[0].SkullIndexes)
                                            {
                                                var skull_temp = response.Definitions.ScriptedSkulls.ToArray()[skullId];
                                                weeklyNightfall.Modifiers.Add(new ActivitySkull() { DisplayName = skull_temp.Value.SkullName, Icon = skull_temp.Value.IconPath, Description = skull_temp.Value.Description});
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
                                    }
                                    weeklyNightfall.ResetTime = response.Advisors.NightfallResetDate;
                                    weeklyNightfall.ActivityType = weeklyNightfallType; // ACTIVTYTYPE TEMP

                                    //Add to model
                                    model.WeeklyNightfall = weeklyNightfall;
                                }
                            }
                        }
                    }
                }
            }

            return model;
        }

        /// <summary>
        ///     This returns the Gamertag associated with all Platforms that match the inputed Gamertag name (Exact Gamertag) 
        /// </summary>
        public async Task<List<UserInfo>> PlayerSearchListAsync(string player)
        {
            var response = await service.SearchPlayers(MembershipType.All, player);
            return response.ToList();
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
            var membershipType = ConversionService.GetMembershipType(platform);
            long membershipId = long.Parse(membershipid);
            List<CharacterSelection> result = new List<CharacterSelection>();

            //Set/Get Response
            GetAccountSummaryResponse response = await service.GetAccountSummary(membershipType, membershipId);

            //Loop through Characters
            foreach(Character character in response.AccountSummary.Characters)
            {
                //Temp Var
                CharacterSelection tempCharacter = new CharacterSelection();

                //Additional Character Info
                GetCharacterResponse charResponse = await service.GetCharacter(membershipType, membershipId, long.Parse(character.CharacterBase.CharacterId));
                GetDefinitionResponse defResponse = await service.GetDefinition(DefinitionType.Race, character.CharacterBase.RaceHash);
                //Set Values
                tempCharacter.Class = ConversionService.GetCharacterClass(character.CharacterBase.ClassType).ToString();
                tempCharacter.EmblemBackgroundPath = "https://www.bungie.net" + charResponse.Character.BackgroundPath;
                tempCharacter.CharacterID = character.CharacterBase.CharacterId;
                tempCharacter.EmblemPath = "https://www.bungie.net" + charResponse.Character.EmblemPath;
                tempCharacter.Gender = ConversionService.GetGenderType(character.CharacterBase.GenderType).ToString();
                tempCharacter.Level = charResponse.Character.BaseCharacterLevel;
                tempCharacter.LightLevel = character.CharacterBase.PowerLevel;
                tempCharacter.Race = defResponse.Definition.Race.RaceName;

                //Add to List
                result.Add(tempCharacter);
            }

            return result;
        }
    }
}