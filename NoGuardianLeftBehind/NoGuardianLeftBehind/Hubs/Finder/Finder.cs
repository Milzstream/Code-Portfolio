using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Business.Library;
using Data;
using System.Threading.Tasks;

namespace NoGuardianLeftBehind.Hubs.Finder
{
    public class Finder : Hub
    {
        public async Task JoinGroup(String Username, String Class, String Platform, int LightLevel, Boolean HasMic, Boolean RequireMic, int playercount, String content, int minimumLightLevel)
        {
            //variables
            Database db = new Database();
            Group group = null;
            List<Player> player = null;

            //Create Player
            db.CreatePlayer(Username, Context.ConnectionId, Platform, Class, HasMic, RequireMic, LightLevel, playercount - 1);

            //Get Group
            group = db.GetGroup(db.JoinGroup(Username, Context.ConnectionId, content, minimumLightLevel));

            //Get Player
            player = db.GetGroupPlayer(Username, Context.ConnectionId, group.Name);

            //  Add Player to gRoup
            await Groups.Add(Context.ConnectionId, group.Name);
            this.AddToFireTeam(player, group);

            if (group.PlayerCount == group.MAX_FIRETEAM_SIZE)
            {
                this.SendSystemMessage(group.Name, "Fireteam is Full!");
            }
        }

        public override Task OnDisconnected(Boolean stopCalled)
        {
            //Variables
            Database db = new Database();
            String username = db.GetPlayerName(Context.ConnectionId);
            Group group = db.GetGroup(db.GetGroupName(username, Context.ConnectionId));
            List<Player> player = db.GetGroupPlayer(username, Context.ConnectionId, group.Name);

            this.RemoveFromFireTeam(player, group);

            // Add your own code here.
            // For example: in a chat application, mark the user as offline, 
            // delete the association between the current connection id and user name.
            return base.OnDisconnected(stopCalled);
        }

        public void RemoveFromFireTeam(List<Player> player, Group group)
        {
            //Variables
            Player main_player = player.Last();

            //Remove Player from Group
            Groups.Remove(Context.ConnectionId, group.Name);

            //Variables
            Database db = new Database();

            //Remove from DB
            db.LeaveGroup(main_player.Username, main_player.Connection, group.Name);
            db.DeletePlayer(main_player.Username, main_player.Connection);

            if ((group.PlayerCount - player.Count) > 0)
            {
                foreach (Player plyr in player)
                {
                    this.SendSystemMessage(group.Name, plyr.Username + " has Left.");
                    Clients.Group(group.Name).removeFireteam(plyr.PlayerPosition.ToString());
                }
            }
        }

        public void AddToFireTeam(List<Player> player, Group group)
        {
            //Variables
            Player main_player = player.Last();

            foreach (Message msg in group.GroupChat)
            {
                Clients.Client(main_player.Connection).addChatMessage(msg.Player, msg.Text);
            }

            //Adding Players to Fireteam-Sidebar in View
            foreach (Player temp_plyr in group.ViewPlayers)
            {
                //Adding player to the new player's client
                if (!player.Contains(temp_plyr))
                {
                    Clients.Client(player.Last().Connection).updateFireTeam(temp_plyr.PlayerPosition.ToString(), temp_plyr.Username, temp_plyr.LightLevel, temp_plyr.HasMic, temp_plyr.Class);
                }
                else //Adding to player to everyone in the group
                {
                    Clients.Group(group.Name).updateFireTeam(temp_plyr.PlayerPosition.ToString(), temp_plyr.Username, temp_plyr.LightLevel, temp_plyr.HasMic, temp_plyr.Class);

                    //Messages
                    this.SendSystemMessage(group.Name, temp_plyr.Username + " joined.");
                }
            }
        }

        //This is used for client message sending (doesn't work for Systems)
        public void SendMessage(String Username, String Message)
        {
            //varaibles
            Database db = new Database();
            Group group = db.GetGroup(db.GetGroupName(Username, Context.ConnectionId));

            //Add Message to Group
            db.AddGroupMessage(group.Name, Username, Message);
            Clients.Group(group.Name).addChatMessage(Username, Message);
        }

        // This is used to Send System Messages
        public void SendSystemMessage(String GroupName, String Message)
        {
            //Variables
            Database db = new Database();

            //Add Message to Group
            db.AddGroupMessage(GroupName, "SYSTEM", Message);
            Clients.Group(GroupName).addChatMessage("SYSTEM", Message);
        }
    }
}