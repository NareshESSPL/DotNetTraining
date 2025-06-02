using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace MAIN
{
    public class cricketdal
    {
        private readonly string ConnectionString;
        public cricketdal(string connectionString)
        {
            ConnectionString = connectionString;
        }
        // This class is used to store the player's name.
        public List<HELP.helpp> GetPlayers(int v)
        {
            List<HELP.helpp> players = new List<HELP.helpp>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT PlayerId, PlayerName, Age FROM Players", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HELP.helpp player = new HELP.helpp
                            {
                                PlayerId = reader.GetInt32(0),
                                PlayerName = reader.GetString(1),
                                Age = reader.GetInt32(2)
                            };
                            players.Add(player);
                        }
                    }
                }
            }
            return players;
        }
        public void AddPlayer(HELP.helpp player)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Players (PlayerName, Age) VALUES (@PlayerName, @Age)", connection))
                {
                    command.Parameters.AddWithValue("@PlayerName", player.PlayerName);
                    command.Parameters.AddWithValue("@Age", player.Age);
                    command.ExecuteNonQuery();
                }
            }
        }
        // Fix for IDE1007 and CS1519: Replace 'Public' with 'public' to correct the syntax error.  
        public void DeletePlayer(int playerId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Players WHERE PlayerId = @PlayerId", connection))
                {
                    command.Parameters.AddWithValue("@PlayerId", playerId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdatePlayer(HELP.helpp player)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Players SET PlayerName = @PlayerName, Age = @Age WHERE PlayerId = @PlayerId", connection))
                {
                    command.Parameters.AddWithValue("@PlayerName", player.PlayerName);
                    command.Parameters.AddWithValue("@Age", player.Age);
                    command.Parameters.AddWithValue("@PlayerId", player.PlayerId);
                    command.ExecuteNonQuery();
                }
            }
        }

        
    }
}
