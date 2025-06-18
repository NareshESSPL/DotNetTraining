using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlTypes;
using TestApp.DTO;

namespace TestApp.DataLayer
{
    public class EmployeeDAL
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;

        public EmployeeDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("ConString");
        }

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
                        employee.FileName = reader.IsDBNull("FileName") ? string.Empty : reader.GetString("FileName");
                        employee.IDImageFileName = !reader.IsDBNull("IDFileName") ? reader.GetString("IDFileName") : default;

                        employees.Add(employee);

                    }
                }
            }

            return employees;
        }

        public DataTable GetEmployeesAsTable()
        {
            var dtEmployee = new DataTable();

            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("Select Id, Name, Age From Employee", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;

                    var adp = new SqlDataAdapter(sqlCmd);

                    adp.Fill(dtEmployee);
                }
            }

            return dtEmployee;
        }

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
                    
                    if (employee.FileName == null)
                        sqlCmd.Parameters.Add(new SqlParameter("@FileName", DBNull.Value));
                    else
                        sqlCmd.Parameters.Add(new SqlParameter("@FileName", employee.FileName));

                    if (employee.IDImageFileName == null)
                        sqlCmd.Parameters.Add(new SqlParameter("@IDFileName", DBNull.Value));
                    else
                        sqlCmd.Parameters.Add(new SqlParameter("@IDFileName", employee.IDImageFileName));

                    if (employee.IDImageAsByteArray == null)
                        sqlCmd.Parameters.Add(new SqlParameter("@IDImage", System.Data.SqlTypes.SqlBinary.Null));
                    else
                        sqlCmd.Parameters.Add(new SqlParameter("@IDImage", employee.IDImageAsByteArray));

                    sqlCon.Open();

                    sqlCmd.ExecuteNonQuery();
                }
            }
        }

        public Employee GetEmployee(int id)
        {

            var employee = new Employee();

            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("Select * From Employee", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;

                    sqlCon.Open();

                    var reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        employee.Id = reader.GetInt32("Id");
                        employee.Name = reader.GetString("Name");
                        employee.Age = reader.GetInt32("Age");
                        employee.Gender = reader.GetInt32("Gender");
                        employee.IDImageFileName = !reader.IsDBNull("IDFileName") ? reader.GetString("IDFileName") : default;
                        employee.IDImageAsByteArray = !reader.IsDBNull("IDImage") ? (byte[])reader["IDImage"] : default;

                    }
                }
            }

            return employee;
        }

        public (List<Employee>, List<GradeViewModel>) GetEmployeesAndGrades()
        {
            var employees = new List<Employee>();
            var grades = new List<GradeViewModel>();

            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("sp_GetEmployeeAndGrade", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

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

                    reader.NextResult();

                    while (reader.Read())
                    {
                        var grade = new GradeViewModel();
                        grade.Id = reader.GetInt32("Id");
                        grade.Grade = reader.GetString("Grade");

                        grades.Add(grade);
                    }
                }
            }

            return (employees, grades);
        }

        public DataSet GetEmployeesAndGradesInDs()
        {
            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("sp_GetEmployeeAndGrade", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        public void BulkInsert(DataTable dt)
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (var bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = "Employee";

                    foreach (DataColumn col in dt.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                    }

                    bulkCopy.WriteToServer(dt);
                }
            }
        }

    }
}
