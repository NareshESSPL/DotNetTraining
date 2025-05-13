using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Data;
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

        public IActionResult Test()
        {
            //var data = _employeeDAL.GetEmployeesAndGrades();

            //return View(data);

            var ds = _employeeDAL.GetEmployeesAndGradesInDs();

            List<Employee> employees = new List<Employee>();
            List<GradeViewModel> grades = new List<GradeViewModel>();

            var dtEmployee = ds.Tables[0];

            foreach (DataRow dr in dtEmployee.Rows)
            {
                var employee = new Employee();

                employee.Id = Convert.ToInt32(dr["Id"]);
                employee.Name = Convert.ToString(dr["Name"]);
                employee.Gender = Convert.ToInt32(dr["Gender"]);
                employee.Age = Convert.ToInt32(dr["Age"]);

                employees.Add(employee);
            }

            var dtGrades = ds.Tables[0];
            foreach (DataRow dr in dtGrades.Rows)
            {
                var grade = new GradeViewModel();

                grade.Id = Convert.ToInt32(dr["Id"]);
                grade.Grade = Convert.ToString(dr["Grade"]);

                grades.Add(grade);
            }

            return View((employees, grades))

        }
    }
}
