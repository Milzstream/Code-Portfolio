using Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Library
{
    public class Group
    {
        //p variables
        private List<Player> _players;
        private int _group_size;

        //variables
        public String Name { private set; get; }
        public String Content { private set; get; }
        public List<Message> GroupChat { get; set; }
        public PLATFORM Platform { get; private set; }
        public Boolean RequireMic { get; private set; }
        public int PlayerCount { get { return _players.Count; } }
        public List<Player> ViewPlayers { get { return _players; } }
        public int MAX_FIRETEAM_SIZE { get { return _group_size; } }

        public Group(String name, String content, PLATFORM platform, Boolean requiremic, int group_size, List<Player> players)
        {
            Name = name;
            Platform = platform;
            RequireMic = requiremic;
            _players = players;
            GroupChat = new List<Message>();
            _group_size = group_size;
        }

        public Player GetPlayerByUsername(String Username)
        {
            return _players.Find(p => p.Username == Username);
        }

        public Player GetPlayerByConnection(String Connection)
        {
            return _players.Find(p => p.Connection == Connection);
        }

        public override bool Equals(object obj)
        {
            Group temp = (obj as Group);

            if (temp != null && temp.Name == this.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean MeetMicRequirements(Player player)
        {
            Boolean result = false;
            switch (RequireMic)
            {
                case true: if (player.HasMic) { result = true; } else { result = false; }
                    break;

                case false: if (!player.RequireMic) { result = true; } else { result = false; }
                    break;
            }

            return result;
        }

        private int CalculatePlayerPosition()
        {
            //variables
            int positon = 0;

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].PlayerPosition == positon)
                {
                    positon++;
                    i = 0;
                }
            }

            return positon;
        }
    }
}