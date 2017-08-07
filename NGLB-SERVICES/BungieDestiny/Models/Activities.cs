using Newtonsoft.Json;

namespace BungieDestiny.Models
{
    public sealed class Activities
    {
        [JsonProperty("prisonofelders")]
        public Activity PrisonOfElders { get; set; }
    }
}
