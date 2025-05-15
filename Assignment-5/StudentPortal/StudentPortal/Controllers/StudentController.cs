using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Models.Services;

namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            var results = _studentService.GetStudent();
            return View(results);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.AddStudent(student); 
                return RedirectToAction("Index");
            }

            return View(student);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _studentService.GetStudentById(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Details(int id)
        {
            var student = _studentService.GetStudentById(id); // Fetch from service or repository
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    

    }
}
