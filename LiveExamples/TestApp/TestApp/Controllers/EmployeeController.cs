using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Data;
using System.IO;
using System.Reflection;
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
            SetViewData();

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Submit(Employee employee)
        {
            ModelState.Remove(nameof(employee.Id));
            ModelState.Remove(nameof(employee.FileName));
            ModelState.Remove(nameof(employee.EmployeeImage));
            ModelState.Remove(nameof(employee.IDImage));
            ModelState.Remove(nameof(employee.IDImageFileName));
            ModelState.Remove(nameof(employee.IDImageAsByteArray));

            if (ModelState.IsValid)
            {
                //Buffered Model Binding – Loads the entire file into memory before processing.

                //Option 1 upload to a folder in hosted server
                if (employee.EmployeeImage != null && employee.EmployeeImage.Length > 0)
                {
                    var filename = Guid.NewGuid().ToString();
                    var fileExtension = Path.GetExtension(employee.EmployeeImage.FileName);
                    var fileFullName = string.Concat(filename, fileExtension);

                    var filePath = Path.Combine("wwwroot/uploads/", fileFullName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        employee.EmployeeImage.CopyTo(stream);
                    }

                    employee.FileName = fileFullName;
                }

                ModelState.AddModelError("EmployeeImage", "Please upload a valid file.");

                //Option 2 upload to a column in DB
                if (employee.IDImage != null && employee.IDImage.Length > 0)
                {
                    var filename = Guid.NewGuid().ToString();
                    var fileExtension = Path.GetExtension(employee.IDImage.FileName);

                    if (!fileExtension.Contains("png"))
                        ModelState.AddModelError("IDImageFileName", "Please uplaod a png file");

                    var fileFullName = string.Concat(filename, fileExtension);


                    using (var memoryStream = new MemoryStream())
                    {
                        employee.IDImage.CopyTo(memoryStream);

                        employee.IDImageAsByteArray = memoryStream.ToArray();
                    }

                    employee.IDImageFileName = fileFullName;
                }

                _employeeDAL.AddEmployee(employee);

                return RedirectToAction("Index"); // Redirect to the list of employee
            }

            SetViewData();

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

            var dtGrades = ds.Tables[1];
            foreach (DataRow dr in dtGrades.Rows)
            {
                var grade = new GradeViewModel();

                grade.Id = Convert.ToInt32(dr["Id"]);
                grade.Grade = Convert.ToString(dr["Grade"]);

                grades.Add(grade);
            }

            return View((employees, grades));

        }

        private void SetViewData()
        {
            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem("Male", "1"));
            gender.Add(new SelectListItem("Female", "2"));
            gender.Add(new SelectListItem("Others", "3"));

            ViewData["Gender"] = gender;

            List<SelectListItem> benefit = new List<SelectListItem>();
            benefit.Add(new SelectListItem("PF", "1"));
            benefit.Add(new SelectListItem("Insurance", "2"));
            benefit.Add(new SelectListItem("LTC", "3"));

            ViewData["Benefit"] = benefit;
        }
    }
}
