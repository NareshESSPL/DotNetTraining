using System.Data;
using Microsoft.Data.SqlClient;
using WebApplication1.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataLayer
{
    public class PersonsDAL
    {
        public List<Person> GetPersons()
        {
            var persons = new List<Person>();

            //public List<int , string> Persons = new Person<>
            using (var sqlcon = new SqlConnection("Data Source = ESSPLLAP290\\SQL2019; Initial Catalog = TestApp; Integrated Security = SSPI; TrustServerCertificate = True"))
            {
                using (var sqlCmd = new SqlCommand("select * from Person", sqlcon))
                {
                    sqlCmd.CommandType = CommandType.Text;

                    sqlcon.Open();

                    var reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //reader.GetColumnSchema();// for checking purpose
                        var id = reader.GetInt32("id");
                        var name = reader.GetString("name");

                        var person = new Person { Id = id, Name = name };

                        persons.Add(person);
                    }
                }
            }
            return persons;
        }
       
    }
       
}
