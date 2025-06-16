using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataLayer
{
    public class StudentDAL
    {

        private readonly  string _connectionString;
        private IConfiguration _configuration;
        private  Student st;




        public StudentDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("ConString");

        }

        public byte[] ConvertToByteArray(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
             file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }


        public IFormFile ConvertToIFormFile(byte[] fileBytes, string fileName, string ImageName)
        {
            var stream =  new MemoryStream(fileBytes);
            return new FormFile(stream, 0, fileBytes.Length, ImageName, fileName)
            {
                Headers = new HeaderDictionary(), // Required to avoid exceptions
                ContentType = "application/octet-stream" // Adjust MIME type dynamically
            };
        }



        // Create 
        public void AddStudent(Student student)
        {

            using (var sqlConn = new SqlConnection(_connectionString))
            {

                using (var sqlcmd = new SqlCommand("AddStudent", sqlConn))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;

                   

                    try
                    {

                        byte[]? imageBytes = student.EmployeeImage != null ? ConvertToByteArray(student.EmployeeImage) : null;
                        byte[]? imageBytes1 = student.IDImage != null ? ConvertToByteArray(student.IDImage) : null;

                        sqlcmd.Parameters.Add(new SqlParameter("@RegistrationID", student.StudentRegistrationId));
                        sqlcmd.Parameters.Add(new SqlParameter("@Name", student.StudentName));
                        sqlcmd.Parameters.Add(new SqlParameter("@Age", student.StudentAge));
                        sqlcmd.Parameters.Add(new SqlParameter("@EmailID", student.StudentEmailId));
                        sqlcmd.Parameters.Add(new SqlParameter("@FileName", student.FileName));
                        sqlcmd.Parameters.Add(new SqlParameter("@IDFileName", student.IDFileName));


                        sqlcmd.Parameters.Add(new SqlParameter("@Image", SqlDbType.VarBinary)
                        { Value = (object)imageBytes ?? DBNull.Value });

                        sqlcmd.Parameters.Add(new SqlParameter("@IDImage", SqlDbType.VarBinary)
                        { Value = (object)imageBytes ?? DBNull.Value });

                        //if (student.EmployeeImage != null)
                        //{
                        //    SqlParameter imageParam = new SqlParameter("@Image", SqlDbType.VarBinary);
                        //    imageParam.Value = student.EmployeeImage;
                        //    sqlcmd.Parameters.Add(imageParam);
                        //}
                        //else
                        //{
                        //    SqlParameter imageParam = new SqlParameter("@Image", SqlDbType.VarBinary);
                        //    imageParam.Value = DBNull.Value;
                        //    sqlcmd.Parameters.Add(imageParam);
                        //}

                        //if (student.IDImage != null)
                        //{
                        //    SqlParameter imageParam1 = new SqlParameter("@IDImage", SqlDbType.VarBinary);
                        //    imageParam1.Value = student.IDImage;
                        //    sqlcmd.Parameters.Add(imageParam1);
                        //}
                        //else
                        //{
                        //    SqlParameter imageParam1 = new SqlParameter("@IDImage", SqlDbType.VarBinary);
                        //    imageParam1.Value = DBNull.Value;
                        //    sqlcmd.Parameters.Add(imageParam1);
                        //}


                        //sqlcmd.Parameters.Add(new SqlParameter("@Image", SqlDbType.VarBinary).Value = student.EmployeeImage);
                        sqlcmd.Parameters.Add(new SqlParameter("@Gender", student.StudentGender));
                        sqlcmd.Parameters.Add(new SqlParameter("@Birthday", student.StudentBirthday));
                       
                        sqlConn.Open();
                        sqlcmd.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }
        }




        //// Read
        public Student GetStudent(int id)
        {

            Student student = null;

            using (var SqlConn = new SqlConnection(_connectionString))
            {
                using (var sqlcmd = new SqlCommand("select * from Student where RegistrationID =" + id + "", SqlConn))
                {
                    sqlcmd.CommandType = CommandType.Text;
                    SqlConn.Open();

                    var reader = sqlcmd.ExecuteReader();


                    while (reader.Read())
                    {
                        //byte[]? imageBytes = reader["Image"] is DBNull ? null : ConvertToByteArrayAsync(st.EmployeeImage);
                        //byte[]? imageBytes1 = reader["IDImage"] is DBNull ? null : ConvertToByteArrayAsync(st.IDImage);

                        var EmployeeImageAsByteArray1 = reader["Image"] is DBNull ? null : (byte[])reader["Image"];
                        var IDImageAsByteArray1 = reader["IDImage"] is DBNull ? null : (byte[])reader["IDImage"];


                        student = new Student()
                        {
                            StudentRegistrationId = reader.GetInt32("RegistrationID"),
                            StudentName = reader.GetString("Name"),
                            StudentAge = reader.GetInt32("Age"),
                            StudentEmailId = reader.GetString("EmailID"),
                            StudentGender = reader.GetInt32("Gender"),
                            FileName = reader.GetString("FileName"),
                            EmployeeImageAsByteArray = EmployeeImageAsByteArray1,
                            IDImageAsByteArray = IDImageAsByteArray1,
                           // EmployeeImage = ConvertToIFormFile((byte[])reader["Image"], reader.GetString("FileName"), "EmloyeeImage"), // Check for null before creating MemoryStream
                            StudentBirthday = reader.GetString("Birthday"),
                            IDFileName = reader.GetString("IDFileName"),
                            // IDImage = ConvertToIFormFile((byte[])reader["IDImage"], reader.GetString("FileName"), "IDImage")

                        };
                    }
                }
            }

            return student;

        }

        // Get all Students!!
        public async Task<List<Student>> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            Student student = null;

            

            using (var sqlConn = new SqlConnection(_connectionString))
            {
                using (var sqlCmd = new SqlCommand("SELECT * FROM Student", sqlConn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.Text;
                     await sqlConn.OpenAsync();

                    var reader = await sqlCmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        var id = reader.GetInt32(reader.GetOrdinal("RegistrationID"));
                        var name = reader.GetString(reader.GetOrdinal("Name"));
                        var age = reader.GetInt32(reader.GetOrdinal("Age"));
                        var email = Convert.ToString(reader["EmailID"]);
                        var gender = reader.GetInt32(reader.GetOrdinal("Gender"));
                        var fileName = reader.GetString(reader.GetOrdinal("FileName"));
                        var IDfileName = reader.GetString(reader.GetOrdinal("IDFileName"));

                        var birthday = reader.GetString(reader.GetOrdinal("Birthday"));

                      

                        var EmployeeImageAsByteArray1 = reader["Image"] is DBNull ? null : (byte[])reader["Image"];
                        var IDImageAsByteArray1 = reader["IDImage"] is DBNull ? null : (byte[])reader["IDImage"];

                        

                        student = new Student()
                        {
                            StudentRegistrationId = id,
                            StudentName = name,

                             
                             
                             StudentAge = age,
                            StudentBirthday = birthday,
                            FileName = fileName,
                             EmployeeImageAsByteArray = EmployeeImageAsByteArray1,
                             IDImageAsByteArray = IDImageAsByteArray1,
                             //EmployeeImage = EmployeeImageAsByteArray1 != null ? ConvertToIFormFile(EmployeeImageAsByteArray1, fileName, "EmployeeImage" ): null,
                             //IDImage = IDImageAsByteArray1 != null ? ConvertToIFormFile(IDImageAsByteArray1, fileName, "IDImage") : null,
                             //EmployeeImage = EmployeeImageAsByteArray1 != null ? (IFormFile)new MemoryStream(EmployeeImageAsByteArray1) : null,

                             //IDImage = IDImageAsByteArray1 != null ? (IFormFile)new MemoryStream(IDImageAsByteArray1) : null,
                             StudentGender = gender,
                            StudentEmailId = email
                        };

                        //byte[] imageBytes = student.EmployeeImageAsByteArray ?? Array.Empty<byte>();
                        //student.EmployeeImage = ConvertToIFormFile(imageBytes, student.FileName,"EmployeeImage");

                        //byte[] idImageBytes = student.IDImageAsByteArray ?? Array.Empty<byte>();
                        //student.IDImage = ConvertToIFormFile(idImageBytes, student.IDFileName, "IDImage");




                        // Optional: Add logging for better tracking
                        // _logger?.LogInformation("Adding student: {StudentId}, Name: {StudentName}", id, name);

                        students.Add(student);

                    }
                }
                return students;
            }
        }


        // delete
        public void StudentDelete(int id)
        {
            using (var SqlConn = new SqlConnection(_connectionString))
            {
                using(var sqlCmd=new SqlCommand("DeleteStudent",SqlConn))
                {
                   
                    sqlCmd.CommandType=CommandType.StoredProcedure;
                    SqlConn.Open();

                    sqlCmd.Parameters.Add(new SqlParameter("@RegistrationID",id));
                    sqlCmd.ExecuteNonQuery();


                }
            }
        }

        public async Task<List<Student>> SearchStudentsAsync(string query)
        {
            var students = new List<Student>();
            

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string sqlQuery = @"SELECT RegistrationId, Name, Age, EmailId, FileName,Image,Gender, Birthday,IDFileName, IDImage 
                                FROM Student 
                                WHERE Name LIKE @Query";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Query", $"%{query}%");

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var EmployeeImageAsByteArray1 = reader["Image"] is DBNull ? null : (byte[])reader["Image"];
                            var IDImageAsByteArray1 = reader["IDImage"] is DBNull ? null : (byte[])reader["IDImage"];


                            students.Add(new Student
                            {
                                StudentRegistrationId = reader.GetInt32(0),
                                StudentName = reader.GetString(1),
                                StudentAge = reader.GetInt32(2),
                                StudentEmailId = reader.GetString(3),
                                FileName = reader.GetString(4),
                                EmployeeImageAsByteArray = EmployeeImageAsByteArray1,
                                IDImageAsByteArray = IDImageAsByteArray1,
                                IDFileName = reader.GetString(8),
                                StudentGender = reader.GetInt32(6),

                                StudentBirthday = reader.GetString(7)
                            });
                        }
                    }
                }
            }
            return students;
        }

        //public async Task AddImage(IFormFile file)
        //{
           
        //    if(file.Length >0 && file != null)
        //    {
        //        using (var memory=new MemoryStream())
        //        {
        //            await file.CopyToAsync(memory);
        //            byte[] imageData = memory.ToArray();

        //            using (var sqlConn = new SqlConnection(_connectionString))
        //            {
        //                using (var sqlCmd = new SqlCommand("Insert into Student(FileName,Image) values(@FileName,@Image)", sqlConn))
        //                {
        //                    sqlCmd.CommandType = CommandType.Text;
        //                    sqlCmd.Parameters.Add(new SqlParameter("@FileName", file.FileName));
        //                    sqlCmd.Parameters.Add(new SqlParameter("@Image", SqlDbType.VarBinary).Value=imageData);
        //                    sqlConn.Open();
        //                    await sqlCmd.ExecuteNonQueryAsync();
        //                }
        //            }
        //        }
        //    }



        //}
    }
        



    }

