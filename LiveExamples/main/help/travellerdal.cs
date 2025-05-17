using main;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace WebApplicationflight.DataLayer
{
    public class TravellerDAL
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;

        public TravellerDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("ConString");
        }

        // Fetch all travellers
        public List<Traveller> GetTravellers()
        {
            var travellers = new List<Traveller>();

            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("SELECT * FROM Traveller", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCon.Open();
                    var reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var traveller = new Traveller
                        {
                            Name = reader["Name"].ToString(),
                            TicketNo = Convert.ToInt32(reader["TicketNo"]),
                            SeatNo = Convert.ToInt32(reader["SeatNo"]),
                            FlightName = reader["FlightName"].ToString()
                        };

                        travellers.Add(traveller);
                    }
                }
            }

            return travellers;
        }

        // Insert new traveller (no stored procedure)
        public void AddTraveller(Traveller traveller)
        {
            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                string query = "INSERT INTO Traveller (Name, TicketNo, SeatNo, FlightName) VALUES (@Name, @TicketNo, @SeatNo, @FlightName)";
                using (var sqlCmd = new SqlCommand(query, sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Name", traveller.Name);
                    sqlCmd.Parameters.AddWithValue("@TicketNo", traveller.TicketNo);
                    sqlCmd.Parameters.AddWithValue("@SeatNo", traveller.SeatNo);
                    sqlCmd.Parameters.AddWithValue("@FlightName", traveller.FlightName);

                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }

    
        public void UpdateTraveller(Traveller traveller)
        {
            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                string query = "UPDATE Traveller SET Name = @Name, SeatNo = @SeatNo, FlightName = @FlightName WHERE TicketNo = @TicketNo";
                using (var sqlCmd = new SqlCommand(query, sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Name", traveller.Name);
                    sqlCmd.Parameters.AddWithValue("@TicketNo", traveller.TicketNo);
                    sqlCmd.Parameters.AddWithValue("@SeatNo", traveller.SeatNo);
                    sqlCmd.Parameters.AddWithValue("@FlightName", traveller.FlightName);

                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }

        // Delete traveller by TicketNo
        public void DeleteTraveller(int ticketNo)
        {
            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                string query = "DELETE FROM Traveller WHERE TicketNo = @TicketNo";
                using (var sqlCmd = new SqlCommand(query, sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@TicketNo", ticketNo);

                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }

        // Get traveller by TicketNo
        public Traveller GetTraveller(int ticketNo)
        {
            Traveller traveller = null;

            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                string query = "SELECT * FROM Traveller WHERE TicketNo = @TicketNo";
                using (var sqlCmd = new SqlCommand(query, sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@TicketNo", ticketNo);

                    sqlCon.Open();
                    var reader = sqlCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        traveller = new Traveller
                        {
                            Name = reader["Name"].ToString(),
                            TicketNo = Convert.ToInt32(reader["TicketNo"]),
                            SeatNo = Convert.ToInt32(reader["SeatNo"]),
                            FlightName = reader["FlightName"].ToString()
                        };
                    }
                }
            }

            return traveller;
        }

        // Return all travellers as DataSet (optional use for Excel export)
        public DataSet GetAllTravellersDataSet()
        {
            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("SELECT * FROM Traveller", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCon.Open();

                    using (var adp = new SqlDataAdapter(sqlCmd))
                    {
                        var ds = new DataSet();
                        adp.Fill(ds);
                        return ds;
                    }
                }
            }
        }
    }
}
