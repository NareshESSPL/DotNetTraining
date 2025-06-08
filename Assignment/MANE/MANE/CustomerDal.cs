using System.Data.SqlClient;
using SPRT;

namespace MANE
{
    public class CustomerDal
    {
        private readonly String _connectionString;
        public CustomerDal(String connectionString)
        {
            _connectionString = connectionString;
        }
        public List<help> GetCustomers()
        {
            List<help> customer = new List<help>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT CustomerId, Name, Email, ShoesSize, Shoes FROM  Customers", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customer.Add(new help
                            {
                                CustomerId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                                ShoesSize = reader.GetInt32(3),
                                Shoes = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return customer;
        }
        public void AddCustomer(help customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("INSERT INTO Customers (Name, Email, ShoesSize, Shoes) VALUES (@Name, @Email, @ShoesSize, @Shoes)", connection))
                {
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@ShoesSize", customer.ShoesSize);
                    command.Parameters.AddWithValue("@Shoes", customer.Shoes);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateCustomer(help customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE Customers SET Name = @Name, Email = @Email, ShoesSize = @ShoesSize, Shoes = @Shoes WHERE CustomerId = @CustomerId", connection))
                {
                    // Corrected the issue by removing the incorrect 'object customer = null;' line  
                    // and using the 'help customer' parameter directly.  
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@ShoesSize", customer.ShoesSize);
                    command.Parameters.AddWithValue("@Shoes", customer.Shoes);
                    command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteCustomer(int customerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Customers WHERE CustomerId = @CustomerId", connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public help GetCustomerById(int customerId)
        {
            help customer = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT CustomerId, Name, Email, ShoesSize, Shoes FROM Customers WHERE CustomerId = @CustomerId", connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new help
                            {
                                CustomerId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                                ShoesSize = reader.GetInt32(3),
                                Shoes = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return customer;
        }

    }
}
