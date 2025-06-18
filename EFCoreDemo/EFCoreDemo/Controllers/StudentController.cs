using System;
using Microsoft.AspNetCore.Mvc;
using EFCoreDemo.Data;
using EFCoreDemo.Models;

namespace EFCoreDemo.Controllers
{   
    public class StudentController : Controller
    {
    public ApplicationDbContext _context;

    public StudentController(ApplicationDbContext context)
    {
        _context = context;
    }
        public IActionResult Index()
        {
            List<Student> students = _context.Students.ToList();
            return View(students);
        }
    }
}
