using System.Diagnostics;
using help;
using Microsoft.AspNetCore.Mvc;
using school.Models;
using static Student.@class;


 

namespace school.Controllers
{
    public class HomeController : Controller
    {
        private static List<hello> _students = new List<hello>();
        private readonly string _connectionString;
        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
       




        public IActionResult Index()
        {
            return View(_students);
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(hello student)
        {
            if (ModelState.IsValid)
            {
                _students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult UpdateStudent(int rollno)
        {
            var student = _students.FirstOrDefault(s => s.RollNo == rollno);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult UpdateStudent(hello student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = _students.FirstOrDefault(s => s.RollNo == student.RollNo);
                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Age = student.Age;
                    existingStudent.RollNo = student.RollNo;
                }
                return RedirectToAction("Index");
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult DeleteStudent(int rollno)
        {
            var student = _students.FirstOrDefault(s => s.RollNo == rollno);
            if (student == null)
            {
                return NotFound();
            }
            return View(student); // Returns DeleteStudent.cshtml
        }

        [HttpPost]
        public IActionResult DeleteStudentConfirmed(int rollno)
        {
            var student = _students.FirstOrDefault(s => s.RollNo == rollno);
            if (student != null)
            {
                _students.Remove(student);
            }
            return RedirectToAction("Index");
        }



        [HttpGet]
     


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
