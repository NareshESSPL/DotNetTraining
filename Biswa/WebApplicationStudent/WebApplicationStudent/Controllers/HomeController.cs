using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using WebApplicationStudent.Models;
using System;
using System.Collections.Generic;

namespace WebApplicationStudent.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Home/Create or Home/Create?id=5
        public IActionResult Create(int? id)
        {
            var connectionString = _configuration.GetConnectionString("ConString");

            if (id.HasValue)
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "SELECT * FROM Student WHERE StudentID = @StudentID";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", id.Value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var student = new Student
                                {
                                    StudentID = Convert.ToInt32(reader["StudentID"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Age = Convert.ToInt32(reader["Age"]),
                                    EnrollmentDate = Convert.ToDateTime(reader["EnrollmentDate"])
                                };
                                return View(student); // Editing existing
                            }
                        }
                    }
                }
            }

            return View(new Student()); // Creating new
        }

        // POST: Home/Create (Upsert)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            var connectionString = _configuration.GetConnectionString("ConString");

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check existence
                var checkQuery = "SELECT COUNT(*) FROM Student WHERE StudentID = @StudentID";
                using (var checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                    int exists = (int)checkCmd.ExecuteScalar();

                    if (exists > 0)
                    {
                        // UPDATE
                        var updateQuery = @"UPDATE Student 
                            SET FirstName = @FirstName, LastName = @LastName, Age = @Age, EnrollmentDate = @EnrollmentDate 
                            WHERE StudentID = @StudentID";
                        using (var updateCmd = new SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                            updateCmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                            updateCmd.Parameters.AddWithValue("@LastName", student.LastName);
                            updateCmd.Parameters.AddWithValue("@Age", student.Age);
                            updateCmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // INSERT
                        var insertQuery = @"INSERT INTO Student (FirstName, LastName, Age, EnrollmentDate)
                            VALUES (@FirstName, @LastName, @Age, @EnrollmentDate)";
                        using (var insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                            insertCmd.Parameters.AddWithValue("@LastName", student.LastName);
                            insertCmd.Parameters.AddWithValue("@Age", student.Age);
                            insertCmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Home/Index
        public IActionResult Index()
        {
            var students = new List<Student>();
            var connectionString = _configuration.GetConnectionString("ConString");

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var query = "SELECT StudentID, FirstName, LastName, Age, EnrollmentDate FROM Student";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Age = Convert.ToInt32(reader["Age"]),
                                EnrollmentDate = Convert.ToDateTime(reader["EnrollmentDate"])
                            });
                        }
                    }
                }
            }

            return View(students);
        }

        // POST: Home/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var connectionString = _configuration.GetConnectionString("ConString");

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var query = "DELETE FROM Student WHERE StudentID = @StudentID";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", id);
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
