using DataLayer;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace StudentInfo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<StudentController> _logger;
        private readonly StudentDAL _studentDAL;

        public StudentController(ILogger<StudentController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _studentDAL = new StudentDAL(_configuration);
        }

        public IActionResult Index()
        {
            return View(_studentDAL.GetAllStudents());
        }

        public IActionResult Create(Student student)
        {
            ViewData["StudGen"] = GetGenderOptions();
            return View(student);
        }

        [HttpPost]
        public IActionResult SaveStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewData["StudGen"] = GetGenderOptions();
                return View("Create", student);
            }

            _studentDAL.AddStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _studentDAL.StudentDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var studentData = _studentDAL.GetStudent(id);

            ViewData["StudGen"] = GetGenderOptions();
            return View("Edit", studentData); // Use separate Edit view for better clarity
        }

        private List<SelectListItem> GetGenderOptions()
        {
            return new List<SelectListItem>
            {
                new SelectListItem("Male", "1"),
                new SelectListItem("Female", "2"),
                new SelectListItem("Others", "3")
            };
        }
    }
}
