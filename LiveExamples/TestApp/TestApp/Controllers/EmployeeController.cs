using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using TestApp.DataLayer;
using TestApp.DTO;

namespace TestApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeDAL _employeeDAL;

        public EmployeeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _employeeDAL = new EmployeeDAL(_configuration);
        }

        public IActionResult Index()
        {
            var employees = _employeeDAL.GetEmployees();
            return View(employees);
        }

        public IActionResult Create()
        {
            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem("Male", "1"));
            gender.Add(new SelectListItem("Female", "2"));
            gender.Add(new SelectListItem("Others", "3"));

            ViewData["Gender"] = gender;


            return View();
        }

        [HttpPost]
        public ActionResult Submit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeDAL.AddEmployee(employee);
                return RedirectToAction("Index"); // Redirect to the list of employee
            }

            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem("Male", "1"));
            gender.Add(new SelectListItem("Female", "2"));
            gender.Add(new SelectListItem("Others", "3"));

            ViewData["Gender"] = gender;

            return View("Create", employee); // If model is invalid, return the form with errors
        }


        public IActionResult Edit(int id)
        {
            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem("Male", "1"));
            gender.Add(new SelectListItem("Female", "2"));
            gender.Add(new SelectListItem("Others", "3"));

            ViewData["Gender"] = gender;

            var employee = _employeeDAL.GetEmployee(id);


            return View("Create", employee);
        }
    }
}
