using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Sprt;

namespace Headd
{
    public class Customerdal
    {
        private readonly string _connectionString;

        public Customerdal(string connectionString)
        {
            _connectionString = connectionString;
        }

       
        public List<help> AllCustomer
        {
            get
            {
                List<help> list = new List<help>();

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            help customer = new help
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                age = Convert.ToInt32(reader["Age"]),
                                DocumentPath = reader["DocumentPath"].ToString()
                            };
                            list.Add(customer);
                        }
                    }
                }

                return list;
            }
        }

       
        public help GetCustomerById(int id)
        {
            help customer = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customer = new help
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            age = Convert.ToInt32(reader["Age"]),
                            DocumentPath = reader["DocumentPath"].ToString()
                        };
                    }
                }
            }

            return customer;
        }

      
        public void AddCustomer(help customer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Customer (Name, Age, DocumentPath) VALUES (@Name, @Age, @DocumentPath)",
                    conn);

                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Age", customer.age);
                cmd.Parameters.AddWithValue("@DocumentPath", customer.DocumentPath ?? "");

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCustomer(help customer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", customer.Id);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Age", customer.age);
                    cmd.Parameters.AddWithValue("@DocumentPath", customer.DocumentPath ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void DeleteCustomer(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Customer WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
