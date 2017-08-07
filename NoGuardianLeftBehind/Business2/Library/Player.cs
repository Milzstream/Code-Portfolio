using Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Library
{
    public class Player
    {
        public String Username { get; private set; }
        public String Connection { get; private set; }
        public PLATFORM Platform { get; private set; }
        public Boolean HasMic { get; private set; }
        public Boolean RequireMic { get; private set; }
        public int LightLevel { get; private set; }
        public String Class { get; private set; }
        public int PlayerPosition { get; set; }
        public String GroupName { get; set; }
        public int Guests { get; private set; }

        public Player(Profile profile, String connection, int guestCount = 0)
        {
            Username = profile.Username;
            Connection = connection;
            Platform = PLATFORM_HELPER.CONVERT(profile.Platform);
            HasMic = profile.HasMic;
            RequireMic = profile.RequireMic;
            LightLevel = profile.LightLevel;
            Class = profile.Class;
            GroupName = String.Empty;
            Guests = guestCount;
        }

        public override bool Equals(object obj)
        {
            Player temp = (obj as Player);

            if (temp == null)
                return false;

            if ((temp.Username == this.Username || temp.Connection == this.Connection))
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}