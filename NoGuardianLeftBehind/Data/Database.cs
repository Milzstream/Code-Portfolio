using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Business.Library;
using Business.Enums;

namespace Data
{
    public class Database
    {
        public Database()
        {

        }

        /// <summary>
        ///     This Method is Used to Create a Player and Guests
        ///     NOTE: IT does not check if the player exists!
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Connection"></param>
        /// <param name="Platform"></param>
        /// <param name="Class"></param>
        /// <param name="HasMic"></param>
        /// <param name="RequireMic"></param>
        /// <param name="LightLevel"></param>
        /// <param name="Guests"></param>
        public void CreatePlayer(String Username, String Connection, String Platform, String Class, Boolean HasMic, Boolean RequireMic, int LightLevel, int Guests)
        {
            // Variables
            SqlCommand command = new SqlCommand();
            command.CommandText = "dbo.CreatePlayer";
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction transaction = null;

            // Add parameters
            command.Parameters.Add(new SqlParameter("@USERNAME", Username));
            command.Parameters.Add(new SqlParameter("@CONNECTION", Connection));
            command.Parameters.Add(new SqlParameter("@PLATFORM", Platform));
            command.Parameters.Add(new SqlParameter("@CLASS", Class));
            command.Parameters.Add(new SqlParameter("@HAS_MIC", HasMic));
            command.Parameters.Add(new SqlParameter("@REQUIRE_MIC", RequireMic));
            command.Parameters.Add(new SqlParameter("@LIGHT_LEVEL", LightLevel));
            command.Parameters.Add(new SqlParameter("@GUESTS", Guests));

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    command.Connection = connection;
                    command.Transaction = transaction;

                    //Execute and Commit
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        ///     This Method is used to Delete a Player and Guests
        ///     Note: Does Not Check if the Player Exists
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Connection"></param>
        public void DeletePlayer(String Username, String Connection)
        {
            // Variables
            SqlCommand command = new SqlCommand();
            command.CommandText = "dbo.DeletePlayer";
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction transaction = null;

            // Add parameters
            command.Parameters.Add(new SqlParameter("@USERNAME", Username));
            command.Parameters.Add(new SqlParameter("@CONNECTION", Connection));

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    command.Connection = connection;
                    command.Transaction = transaction;

                    //Execute and Commit
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        ///     This Method Joins the Player (and Guests) to a Group and Returns the GroupName
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Connection"></param>
        /// <param name="Content"></param>
        /// <returns>GroupName</returns>
        public String JoinGroup(String Username, String Connection, String Content, int MinimumLightLevel)
        {
            // Variables
            SqlCommand command = new SqlCommand();
            command.CommandText = "dbo.JoinGroup";
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction transaction = null;
            String group_name = String.Empty;

            // Add parameters
            command.Parameters.Add(new SqlParameter("@USERNAME", Username));
            command.Parameters.Add(new SqlParameter("@CONNECTION", Connection));
            command.Parameters.Add(new SqlParameter("@CONTENT", Content));
            command.Parameters.Add(new SqlParameter("@MIN_LIGHT_LEVEL", MinimumLightLevel));

            //OutPut Params
            SqlParameter output = new SqlParameter("@GROUP_NAME", group_name);
            output.Direction = ParameterDirection.InputOutput;
            output.SqlDbType = SqlDbType.VarChar;
            output.Size = 25;
            command.Parameters.Add(output);

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    command.Connection = connection;
                    command.Transaction = transaction;

                    //Execute and Commit
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    group_name = output.Value.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return group_name;
        }

        /// <summary>
        ///     This Method is used to Remove a Player (and Guests) From a Group
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Connection"></param>
        /// <param name="GroupName"></param>
        public void LeaveGroup(String Username, String Connection, String GroupName)
        {
            // Variables
            SqlCommand command = new SqlCommand();
            command.CommandText = "dbo.LeaveGroup";
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction transaction = null;

            // Add parameters
            command.Parameters.Add(new SqlParameter("@USERNAME", Username));
            command.Parameters.Add(new SqlParameter("@CONNECTION", Connection));
            command.Parameters.Add(new SqlParameter("@GROUP_NAME", GroupName));

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    command.Connection = connection;
                    command.Transaction = transaction;

                    //Execute and Commit
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///     This Method is used to return all the players info from a group
        ///     NOTE: Best Used when a New user is added to update there client
        /// </summary>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        public List<Player> GetGroupMembers(String GroupName)
        {
            // Variables
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.CommandText = "dbo.GetGroupMembers";
            command.CommandType = CommandType.StoredProcedure;
            List<Player> group = new List<Player>();
            DataSet result = new DataSet();

            // Add parameters
            command.Parameters.Add(new SqlParameter("@GROUP_NAME", GroupName));

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    command.Connection = connection;
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);

                    foreach(DataRow row in result.Tables[0].Rows)
                    {
                        Profile temp = new Profile(row["USERNAME"].ToString(), row["CLASS"].ToString(), row["PLATFORM"].ToString(), int.Parse(row["LIGHT_LEVEL"].ToString()), (Boolean)(row["HAS_MIC"]), (Boolean)(row["REQUIRE_MIC"]));
                        Player player = new Player(temp, row["CONNECTION"].ToString(), int.Parse(row["GUESTS"].ToString()));
                        player.PlayerPosition = int.Parse(row["POSITION"].ToString());

                        //Add Player to Group
                        group.Add(player);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

            return group;
        }

        /// <summary>
        ///     This Method returns an individual and there guests from a particular group
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Connection"></param>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        public List<Player> GetGroupPlayer(String Username, String Connection, String GroupName)
        {
            // Variables
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.CommandText = "dbo.GetGroupPlayer";
            command.CommandType = CommandType.StoredProcedure;
            List<Player> group = new List<Player>();
            DataSet result = new DataSet();

            // Add parameters
            command.Parameters.Add(new SqlParameter("@USERNAME", Username));
            command.Parameters.Add(new SqlParameter("@CONNECTION", Connection));
            command.Parameters.Add(new SqlParameter("@GROUP_NAME", GroupName));

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    command.Connection = connection;
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);

                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        Profile temp = new Profile(row["USERNAME"].ToString(), row["CLASS"].ToString(), row["PLATFORM"].ToString(), int.Parse(row["LIGHT_LEVEL"].ToString()), (Boolean)(row["HAS_MIC"]), (Boolean)(row["REQUIRE_MIC"]));
                        Player player = new Player(temp, row["CONNECTION"].ToString(), int.Parse(row["GUESTS"].ToString()));
                        player.PlayerPosition = int.Parse(row["POSITION"].ToString());

                        //Add Player to Group
                        group.Add(player);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

            return group;
        }

        /// <summary>
        ///     This Method is used to retrieve the Group Name associated with this user
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Connection"></param>
        /// <returns></returns>
        public String GetGroupName(String Username, String Connection)
        {
            // Variables
            SqlCommand command = new SqlCommand();
            command.CommandText = "dbo.GetGroupName";
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction transaction = null;
            String group_name = String.Empty;

            // Add parameters
            command.Parameters.Add(new SqlParameter("@USERNAME", Username));
            command.Parameters.Add(new SqlParameter("@CONNECTION", Connection));


            //OutPut Params
            SqlParameter output = new SqlParameter("@GROUP_NAME", group_name);
            output.Direction = ParameterDirection.InputOutput;
            output.SqlDbType = SqlDbType.VarChar;
            output.Size = 25;
            command.Parameters.Add(output);

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    command.Connection = connection;
                    command.Transaction = transaction;

                    //Execute and Commit
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    group_name = output.Value.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return group_name;
        }


        /// <summary>
        ///     This Method is used to rerieve a Group
        /// </summary>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        public Group GetGroup(String GroupName)
        {
            // Variables
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.CommandText = "dbo.GetGroupInfo";
            command.CommandType = CommandType.StoredProcedure;
            Group group = null;
            DataSet result = new DataSet();

            // Add parameters
            SqlParameter param = new SqlParameter("@GROUP_NAME", GroupName);
            param.Size = 25;
            param.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(param);

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    command.Connection = connection;
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);

                    group = new Group(
                        result.Tables[0].Rows[0]["NAME"].ToString(),
                        result.Tables[0].Rows[0]["CONTENT"].ToString(),
                        (PLATFORM_HELPER.CONVERT(result.Tables[0].Rows[0]["PLATFORM"].ToString())),
                        ((Boolean)result.Tables[0].Rows[0]["REQUIRE_MIC"]),
                        int.Parse(result.Tables[0].Rows[0]["FIRETEAM_SIZE"].ToString()),
                        GetGroupMembers(GroupName));
                    group.GroupChat = GetGroupChat(GroupName);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return group;
        }

        /// <summary>
        ///     This Method is used to Add a Message to Group Chat
        /// </summary>
        /// <param name="GroupName"></param>
        /// <param name="Username"></param>
        /// <param name="Message"></param>
        public void AddGroupMessage(String GroupName, String Username, String Message)
        {
            // Variables
            SqlCommand command = new SqlCommand();
            command.CommandText = "dbo.AddGroupChat";
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction transaction = null;

            // Add parameters
            command.Parameters.Add(new SqlParameter("@USERNAME", Username));
            command.Parameters.Add(new SqlParameter("@GROUP_NAME", GroupName));
            command.Parameters.Add(new SqlParameter("@MESSAGE", Message));

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    command.Connection = connection;
                    command.Transaction = transaction;

                    //Execute and Commit
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        ///     This Method gets the Group Messages
        /// </summary>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        public List<Message> GetGroupChat(String GroupName)
        {
            // Variables
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.CommandText = "dbo.GetGroupChat";
            command.CommandType = CommandType.StoredProcedure;
            List<Message> chat = new List<Message>();
            DataSet result = new DataSet();

            // Add parameters
            SqlParameter param = new SqlParameter("@GROUP_NAME", GroupName);
            param.Size = 25;
            param.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(param);

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    command.Connection = connection;
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);

                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                       //Variables
                        Message message = new Message(row["USERNAME"].ToString(), row["MESSAGE"].ToString());

                        //Add Message to List
                        chat.Add(message);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

            return chat;
        }

        /// <summary>
        ///     This Method returns all Available Content Types
        /// </summary>
        /// <returns>List of Content Types</returns>
        public List<ContentType> GetAvailableContentTypes()
        {
            // Variables
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.CommandText = "dbo.GetAvailableContentTypes";
            command.CommandType = CommandType.StoredProcedure;
            List<ContentType> contentTypes = new List<ContentType>();
            DataSet result = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    command.Connection = connection;
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);

                    // Loop Through the DataRows and Create the ContentType List
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        contentTypes.Add(new ContentType(row["NAME"].ToString(), row["DESCRIPTION"].ToString(), int.Parse(row["FIRETEAM_SIZE"].ToString()), int.Parse(row["FREQUENCY"].ToString())));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return contentTypes;
        }

        /// <summary>
        ///     This Method gets a players name based on connection
        /// </summary>
        /// <param name="Connection"></param>
        /// <returns></returns>
        public String GetPlayerName(String Connection)
        {
            // Variables
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.CommandText = "dbo.GetPlayerName";
            command.CommandType = CommandType.StoredProcedure;
            String username = String.Empty;
            DataSet result = new DataSet();

            // Add parameters
            command.Parameters.Add(new SqlParameter("@CONNECTION", Connection));

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    command.Connection = connection;
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);

                    username = result.Tables[0].Rows[0]["USERNAME"].ToString();

                }
            }
            catch (Exception)
            {
                username = "UKNOWN";
                //throw;
            }

            return username;
        }

        /// <summary>
        ///     This Method returns a list of the available content to play
        /// </summary>
        /// <param name="LightLevel"></param>
        /// <param name="Platform"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public List<Content> GetAvailableContent(int LightLevel, String Platform, String Content)
        {
            // Variables
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.CommandText = "dbo.GetAvailableContent";
            command.CommandType = CommandType.StoredProcedure;
            List<Content> content = new List<Content>();
            DataSet result = new DataSet();

            // Add parameters
            command.Parameters.Add(new SqlParameter("@LIGHT_LEVEL", LightLevel));
            command.Parameters.Add(new SqlParameter("@PLATFORM", Platform));
            command.Parameters.Add(new SqlParameter("@CONTENT", Content));

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    command.Connection = connection;
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);

                    //Get Content Type
                    ContentType contentType = new ContentType(result.Tables[0].Rows[0]["NAME"].ToString(), result.Tables[0].Rows[0]["DESCRIPTION"].ToString(), int.Parse(result.Tables[0].Rows[0]["FIRETEAM_SIZE"].ToString()), int.Parse(result.Tables[0].Rows[0]["FREQUENCY"].ToString()));

                    // Loop Through the DataRows and Create the ContentType List
                    foreach (DataRow row in result.Tables[1].Rows)
                    {
                        content.Add(new Content(row["NAME"].ToString(), row["PREFIX"].ToString(), row["PLATFORM"].ToString(), int.Parse(row["LIGHT_LEVEL"].ToString()), int.Parse(row["FREQUENCY"].ToString()), contentType));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return content;
        }

        /// <summary>
        ///     This method returns all the checkpoints associated with selected content
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public List<String> GetContentCheckpoints(String Content)
        {
            // Variables
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.CommandText = "dbo.GetContentCheckpoints";
            command.CommandType = CommandType.StoredProcedure;
            List<String> checkpoints = new List<String>();
            DataSet result = new DataSet();

            // Add parameters
            command.Parameters.Add(new SqlParameter("@CONTENT", Content));

            try
            {
                using (SqlConnection connection = new SqlConnection(COMMON.CONNECTION_STRING))
                {
                    connection.Open();
                    command.Connection = connection;
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);

                    // Loop Through the DataRows and Add the Checkpoints
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        checkpoints.Add(row["NAME"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return checkpoints;
        }
    }
}
