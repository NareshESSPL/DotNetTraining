using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using WebApplication1.DTO;

namespace DataLayer
{
    public  class EmployeesDAL
    {
        public List<Employees> GetEmployeedata()
        {
            var data = new List<Employees>();

            using (var sqlcon = new SqlConnection("Data Source = ESSPLLAP290\\SQL2019;Initial Catalog = TestApp;" +
                "Integrated Security = SSPI; TrustServerCertificate = True"))
            {
                using (var sqlCmd = new SqlCommand("select * from Employees", sqlcon))
                {
                    sqlCmd.CommandType = CommandType.Text;

                    sqlcon.Open();

                    var reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var Employeeid = reader.GetInt32("EmployeeId");
                        var Employeename = reader.GetString("EmployeeName");
                        var Employeeage = reader.GetInt32("Age");
                        var Employeegender = reader.GetString("Gender");
                        var employee = new Employees { EmployeeId = Employeeid, EmployeeName = Employeename ,
                                            EmployeeAge = Employeeage , EmployeeGender = Employeegender };

                        data.Add(employee);

                    }

                }
            }
            return data;
        }

        public void AddEmployees(Employees obj)
        {
            try
            {
                using (var sqlcon = new SqlConnection("Data Source = ESSPLLAP290\\SQL2019;Initial Catalog = TestApp; Integrated Security = SSPI; TrustServerCertificate = True"))
                {
                    using (var sqlCmd = new SqlCommand("Insertion", sqlcon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlcon.Open();

                        sqlCmd.Parameters.Add(new SqlParameter("@Name", obj.EmployeeName));
                        sqlCmd.Parameters.Add(new SqlParameter("@Age", obj.EmployeeAge));
                        sqlCmd.Parameters.Add(new SqlParameter("@Gender", obj.EmployeeGender));

                        sqlCmd.ExecuteNonQuery();

                    }
                }
            }
            catch (SqlException ex)
            { 
            Console.WriteLine("Sql Exception happened."+ex.ToString());
            }
        }
    }
}
