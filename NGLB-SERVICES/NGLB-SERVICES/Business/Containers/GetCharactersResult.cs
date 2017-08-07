using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGLB_SERVICES.Business.Containers
{
    /// <summary>
    ///     List of Characters associated with Player
    /// </summary>
    public struct GetCharactersResult
    {
        /// <summary>
        ///     List of Character Objects
        /// </summary>
        public List<CharacterSelection> Characters {get; set;}
    }

    /// <summary>
    ///     Individual Character Object
    /// </summary>
    public struct CharacterSelection
    {
        /// <summary>
        ///  Absolute Image Path of Character Emblem
        /// </summary>
        public string EmblemPath { get; set; }

        /// <summary>
        ///  Absolute Image Path of Character Banner
        /// </summary>
        public string EmblemBackgroundPath { get; set; }

        /// <summary>
        ///     Character Class (Warlock, Titan, Hunter)
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        ///     Character Race (Awoken, Human, Exo)
        /// </summary>
        public string Race { get; set; }

        /// <summary>
        ///     Character Gender (male, female)
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        ///     Character Base Level (40 etc)
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Character Light Level (gear level)
        /// </summary>
        public int LightLevel { get; set; }

        /// <summary>
        ///  Unique ID (number) that represents Player's Character
        /// </summary>
        public string CharacterID { get; set; }
    }
}