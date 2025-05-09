using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp.ADODotNet
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
    }

    public class TestSqlCommand
    {
        public readonly string _connectionstring;

        public TestSqlCommand()
        {
            _connectionstring = "Data Source=VIVAN;Initial Catalog=TestApp;Integrated Security=SSPI;TrustServerCertificate=True";
        }

        /// <summary>
        /// Execute Reader
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();

            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("Select * From Employee", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;

                    sqlCon.Open();

                    var reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var employee = new Employee();
                        employee.Id = reader.GetInt32("Id");
                        employee.Name = reader.GetString("Name");
                        employee.Age = reader.GetInt32("Age");
                        employee.Gender = reader.GetInt32("Gender");

                        employees.Add(employee);

                    }
                }
            }

            return employees;
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployee(Employee employee)
        {
            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("AddEmployee", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(new SqlParameter("@Name", employee.Name));
                    sqlCmd.Parameters.Add(new SqlParameter("@Age", employee.Age));
                    sqlCmd.Parameters.Add(new SqlParameter("@Gender", employee.Gender));

                    sqlCon.Open();

                    sqlCmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// ExecuteScalar get only 1 value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetEmployee(int id)
        {

            var name = string.Empty;

            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("Select top 1 Name From Employee", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;

                    sqlCon.Open();

                    name = (string)sqlCmd.ExecuteScalar();
                }
            }

            return name;
        }


        /// <summary>
        /// DataTable
        /// </summary>
        public void ShowDataSet()
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();

                // Define two SQL query
                string query = "select * from Employee; Select top 2 * from Employee";

                // Create DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                // Create and fill DataSet
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                // Display data
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine($"{row["Id"]}, {row["Name"]}");
                }

                // Display data
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    Console.WriteLine($"{row["Id"]}, {row["Name"]}");
                }
            }
        }


        /// <summary>
        /// DataTable
        /// </summary>
        public void ShowDataTable ()
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();

                // Define two SQL query
                string query = "select * from Employee;";

                // Create DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                // Create and fill DataSet
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);

                // Display data
                foreach (DataRow row in datatable.Rows)
                {
                    Console.WriteLine($"{row["Id"]}, {row["Name"]}");
                }
            }
        }

        /// <summary>
        /// Bulkcopy
        /// </summary>
        public void BulkCopy()
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();

                // Create a DataTable with sample data
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ID", typeof(int));
                dataTable.Columns.Add("Name", typeof(string));

                dataTable.Rows.Add(1, "Alice");
                dataTable.Rows.Add(2, "Bob");
                dataTable.Rows.Add(3, "Charlie");

                // Use SqlBulkCopy to insert data
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "Employee";
                    bulkCopy.WriteToServer(dataTable);
                }

                Console.WriteLine("Bulk insert completed successfully.");
            }
        }

        /*
         //Create this type
        CREATE TYPE EmployeeType AS TABLE (
            ID INT PRIMARY KEY,
            Name VARCHAR(100)
        ); 

        //Create this SP
        CREATE PROCEDURE BulkUpdateEmployees
        @EmployeeData EmployeeType READONLY
        AS
        BEGIN
            UPDATE e
            SET e.Name = t.Name, e.Salary = t.Salary
            FROM Employees e
            INNER JOIN @EmployeeData t ON e.ID = t.ID;
        END;

        */
        public void TablevaluesParam()
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();

                // Create a DataTable matching EmployeeType
                DataTable employeeTable = new DataTable();
                employeeTable.Columns.Add("ID", typeof(int));
                employeeTable.Columns.Add("Name", typeof(string));
                employeeTable.Columns.Add("Salary", typeof(decimal));

                employeeTable.Rows.Add(1, "Alice", 55000);
                employeeTable.Rows.Add(2, "Bob", 65000);

                using (SqlCommand cmd = new SqlCommand("BulkUpdateEmployees", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeData", employeeTable);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Bulk update completed successfully.");
            }
        }
    }
}
