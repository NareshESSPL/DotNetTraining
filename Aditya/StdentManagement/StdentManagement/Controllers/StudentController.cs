using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagement.DataLayer;
using StudentManagementSystem.DTO;

namespace StdentManagement.Controllers
{
    public class StudentController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        private readonly StudentDAL _studentDAL;

        public StudentController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _studentDAL = new StudentDAL(_configuration);
        }
        public IActionResult Index()
        {
            var student = _studentDAL.GetStudents();
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        public ActionResult Submit(Student student)
        {
            ModelState.Remove("StudentID");
            if (ModelState.IsValid)
            {
                _studentDAL.AddStudent(student);
                return RedirectToAction("Index");
            }

            

            return View("Create", student);
        }

        public IActionResult edit(int id)
        {

            var student = _studentDAL.GetStudent(id);
            return View("Create", student);
        }

        public IActionResult delete(int id)
        {
            _studentDAL.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var student = _studentDAL.GetStudent(id);
            return View(student);
        }



    }
}
