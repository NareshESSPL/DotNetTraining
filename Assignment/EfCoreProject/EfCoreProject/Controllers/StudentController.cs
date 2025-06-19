using EfCoreProject.Data;
using EfCoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // List all students
        public IActionResult Index()
        {
            var students = _context.Students.ToList(); // ✅ fixed
            return View(students);
        }

        // Show Add form
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        // Handle Add form submission
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student); // ✅ fixed
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // Show Delete confirmation page
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id); // ✅ fixed
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // Handle Delete post
        [HttpPost]
        public IActionResult DeleteStudentConfirmed(int id)
        {
            var student = _context.Students.Find(id); // ✅ fixed
            if (student != null)
            {
                _context.Students.Remove(student); // ✅ fixed
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Show update form
        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            var student = _context.Students.Find(id); // ✅ fixed
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // Handle update post
        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student); // ✅ fixed
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
