using System.Diagnostics;
using College.Models;
using Microsoft.AspNetCore.Mvc;
using MAINNN;
using SUPORT;
namespace College.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        private readonly StudentDal _studentDal;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IWebHostEnvironment env)
        {
            _logger = logger;
            _configuration = configuration;
            _env = env;
            _studentDal = new StudentDal(_configuration.GetConnectionString("ConString"));
        }

        public IActionResult Index()
        {
            var students = _studentDal.AllStudents;
            return View(students);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

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
        // GET: /Home/UpdateStudent/3
        // ✅ Change your GET method to this:
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
        [HttpPost]
        public IActionResult UpdateStudent(help model)
        {
            if (ModelState.IsValid)
            {
                // ✅ If new file is uploaded, save it and update path
                if (model.Document != null)
                {
                    var fileName = Path.GetFileName(model.Document.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.Document.CopyTo(stream);
                    }
                    model.DocumentPath = "/uploads/" + fileName;
                }
                else
                {
                    // ✅ Get existing document path from DB so it's not lost
                    var existing = _studentDal.GetStudentById(model.Id);
                    model.DocumentPath = existing?.DocumentPath;
                }

                _studentDal.UpdateStudent(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }






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

        [HttpPost, ActionName("DeleteStudent")]
        public IActionResult DeleteStudentConfirmed(int id)
        {
            _studentDal.DeleteStudent(id);
            return RedirectToAction("Index");
        }

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
