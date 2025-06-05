
using System.Data;
using Microsoft.Data.SqlClient;
using MVCUsingAdo.Models;

namespace MVCUsingAdo
{
    public class StudentDal 
    {
        string cs = ConnectionString.dbcs;

        public List<Student> getEmployees()
        {
            List<Student> empList = new List<Student>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("getallData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                //all data  goes to reader

                while (reader.Read())
                {
                    Student s = new Student();
                    s.Id = Convert.ToInt32(reader["Id"]);
                    s.Name = reader["name"].ToString() ?? "";
                    s.age = Convert.ToInt32(reader["age"]);
                    s.marks = Convert.ToInt32(reader["marks"]);

                    empList.Add(s);
                }

            }
            return empList;

        }
        public Student getEmployeeByid(int? id)
        {
            Student emp = new Student();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from Student where id = @id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["name"].ToString() ?? "";
                    emp.age = Convert.ToInt32(reader["age"]);
                    emp.marks = Convert.ToInt32(reader["marks"]);

                }



            }
            return emp;
        }
        public void AddEmployee(Student emp)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", con);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name",emp.Name);
                cmd.Parameters.AddWithValue("@age", emp.age);
                cmd.Parameters.AddWithValue("@marks", emp.marks);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Student emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", emp.Id);
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@age", emp.age);
                cmd.Parameters.AddWithValue("@marks", emp.marks);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteEmployee(int? id)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",id);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

    }
}
