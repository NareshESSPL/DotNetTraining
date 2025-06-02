using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using TestApp1.DTO;

namespace DataLayer
{
    public class EmployeeDAL
    {
        private readonly string _connectionString;

        public EmployeeDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConString");
        }

        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();

            using (var sqlCon = new SqlConnection(_connectionString))
            {
                using (var sqlCmd = new SqlCommand("SELECT * FROM Employee", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCon.Open();

                    var reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var employee = new Employee
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Age = Convert.ToInt32(reader["age"]),
                            Department = Convert.ToString(reader["department"]),
                            Email = Convert.ToString(reader["email"])
                        };

                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                using (var sqlCon = new SqlConnection(_connectionString))
                using (var sqlCmd = new SqlCommand("UpsertEmployee", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.AddWithValue("@Id", employee.Id);
                    sqlCmd.Parameters.AddWithValue("@Name", employee.Name);
                    sqlCmd.Parameters.AddWithValue("@Age", employee.Age);
                    sqlCmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    //sqlCmd.Parameters.AddWithValue("@Department", employee.Department);
                    //sqlCmd.Parameters.AddWithValue("@Email", employee.Email);

                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public Employee GetEmployee(int id)
        {
            var employee = new Employee();
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                using (var sqlCmd = new SqlCommand("Select * From Employee where Id = @Id", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Id", id); // Add this line
                    sqlCon.Open();
                    var reader = sqlCmd.ExecuteReader();

                    if (reader.Read()) // Changed from while to if
                    {
                        employee.Id = reader.GetInt32("Id");
                        employee.Name = reader.GetString("Name");
                        employee.Age = reader.GetInt32("Age");
                        employee.Gender = reader.GetInt32("Gender");
                    }
                }
            }
            return employee;
        }

        public void UpsertEmployee(Employee employee)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                using (var sqlCmd = new SqlCommand("sp_InsertEmployee", sqlCon)) // Changed to sp_InsertEmployee
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Id", employee.Id);
                    sqlCmd.Parameters.AddWithValue("@Name", employee.Name);
                    sqlCmd.Parameters.AddWithValue("@Age", employee.Age);
                    sqlCmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    sqlCmd.Parameters.AddWithValue("@Department", employee.Department); //added missing parameters
                    sqlCmd.Parameters.AddWithValue("@Email", employee.Email);		   //added missing parameters

                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery(); // Executes either insert or update depending on Id
                }
            }
        }
    }
}
