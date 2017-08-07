namespace NGLB_CMS.Business.Containers
{
    public class ProfilePreferences
    {
        public bool HasMic { get; set; }
        public bool RequireMic { get; set; }
        public int SubPlatform { get; set; }
        public string CharacterId { get; set; }
        public string PlatformPassThrough { get; set; }
        public string MembershipidPassThrough { get; set; }
    }
}