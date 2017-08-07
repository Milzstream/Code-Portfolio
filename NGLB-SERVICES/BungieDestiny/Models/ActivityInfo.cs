using Newtonsoft.Json;

namespace BungieDestiny.Models
{
    [JsonObject("display")]
    public sealed class ActivityInfo
    {
        public long CategoryHash { get; set; }

        [JsonProperty("icon")]
        public string IconPath { get; set; }

        [JsonProperty("image")]
        public string PageImage { get; set; }

        public string About { get; set; }
    }
}
