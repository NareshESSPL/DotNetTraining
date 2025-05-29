using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using Help;

namespace Mainn
{
    public class CutomerDal
    {
        private readonly string _connectionString;
        public CutomerDal(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddCutomer(hey customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Customers (Name, Age, Address, OrderId) VALUES (@Name, @Age, @Address, @OrderId)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Age", customer.Age);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.Parameters.AddWithValue("@OrderId", customer.OrderId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateCutomer(hey customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Customers SET Name = @Name, Age = @Age, Address = @Address WHERE OrderId = @OrderId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Age", customer.Age);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.Parameters.AddWithValue("@OrderId", customer.OrderId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteCutomser(hey customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Customers WHERE OrderId = @OrderId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", customer.OrderId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
    

            
       
    


