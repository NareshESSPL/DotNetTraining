using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
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
                using (var sqlCmd = new SqlCommand("select * from Employee", sqlCon))
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

        public void AddEmployee(Employee employee)
        {
            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("AddEmployee", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(new SqlParameter("@Id", employee.Id));
                    sqlCmd.Parameters.Add(new SqlParameter("@Name", employee.Name));
                    sqlCmd.Parameters.Add(new SqlParameter("@Age", employee.Age));
                    sqlCmd.Parameters.Add(new SqlParameter("@Gender", employee.Gender));

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
                using (var sqlCmd = new SqlCommand("Select * From Employee where id =" + id, sqlCon))
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

                    }


                }
            }

            return employee;
        }

        public (List<Employee>, List<GradeViewModel>) GetEmployeeandGrades()
        {

            var employees = new List<Employee>();
            var grades = new List<GradeViewModel>();

            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("sp_GetEmployeeAndGrade", sqlCon))
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
                    reader.NextResult();
                    while (reader.Read())
                    {
                        var grade = new GradeViewModel();
                        grade.ID = reader.GetInt32("Id");
                        grade.Grade = reader.GetString("Grade");

                        grades.Add(grade);
                    }



                }
            }

            return (employees, grades);
        }

        public DataSet GetEmployeesAndgradesInDs()
        {
            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("sp_GetEmployeesAndGrades", sqlCon))
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

            

       