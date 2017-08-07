using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Library
{
    [Serializable]
    public class Profile
    {
        public Profile(String _Username, String _Class, String _Platform, int _LightLevel, Boolean _HasMic, Boolean _RequiredMic)
        {
            Username = _Username;
            Class = _Class;
            Platform = _Platform;
            LightLevel = _LightLevel;
            HasMic = _HasMic;
            RequireMic = _RequiredMic;
        }

        public string Username { get; private set; }
        public int LightLevel { get; private set; }
        public Boolean HasMic { get; private set; }
        public Boolean RequireMic { get; private set; }
        public string Class { get; private set; }
        public string Platform { get; private set; }
    }
}
