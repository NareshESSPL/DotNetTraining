using System;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MAINNN;
using Support;
using Shop.Models;

namespace College.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly StudentDal _studentDal;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IWebHostEnvironment env)
        {
            _logger = logger;
            _configuration = configuration;
            _env = env;

            // Retrieve the connection string named "DefaultConnection" from appsettings.json
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Initialize the StudentDal with the retrieved connection string
            _studentDal = new StudentDal(connectionString);
        }

        // GET: /Home/Index
        public IActionResult Index()
        {
            var students = _studentDal.AllStudents;
            return View(students);
        }

        // GET: /Home/AddStudent
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        // POST: /Home/AddStudent
        [HttpPost]
        public IActionResult AddStudent(help student)
        {
            if (student == null || student.Document == null || student.Document.Length == 0)
            {
                ModelState.AddModelError("Document", "Please upload a document.");
                return View(student);
            }

            string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(student.Document.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                student.Document.CopyTo(stream);
            }

            student.DocumentPath = "/uploads/" + uniqueFileName;
            _studentDal.AddStudent(student);
            return RedirectToAction("Index");
        }

        // GET: /Home/UpdateStudent/5
        [HttpGet]
        public IActionResult UpdateStudent(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var student = _studentDal.GetStudentById(id.Value);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: /Home/UpdateStudent
        [HttpPost]
        public IActionResult UpdateStudent(help model)
        {
            if (ModelState.IsValid)
            {
                if (model.Document != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Document.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.Document.CopyTo(stream);
                    }

                    model.DocumentPath = "/uploads/" + uniqueFileName;
                }
                else
                {
                    var existing = _studentDal.GetStudentById(model.Id);
                    model.DocumentPath = existing?.DocumentPath;
                }

                _studentDal.UpdateStudent(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /Home/DeleteStudent/5
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentDal.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: /Home/DeleteStudent/5
        [HttpPost, ActionName("DeleteStudent")]
        public IActionResult DeleteStudentConfirmed(int id)
        {
            _studentDal.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        // GET: /Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // GET: /Home/Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
