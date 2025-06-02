using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestApp1.DTO;

namespace TestApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmployeeController> _logger;
        private readonly EmployeeDAL _employeeDAL;

        public EmployeeController(ILogger<EmployeeController> logger, IConfiguration configuration)
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

        public IActionResult ShowEmployee()
        {
            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem("Male", "1"));
            gender.Add(new SelectListItem("Female", "2"));
            gender.Add(new SelectListItem("Others", "3"));

            ViewData["Gender"] = gender;
            ViewData["EmployeeList"] = _employeeDAL.GetEmployees();


            return View("Employee");
        }

        [HttpPost]

        [HttpPost]
        public ActionResult Submit(Employee employee)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                //// If Id is 0, it's a new employee; otherwise, update the existing employee
                //if (employee.Id == 0)
                //{
                _employeeDAL.AddEmployee(employee);  // Add new employee
                //}
                //else
                //{
                //    _employeeDAL.UpsertEmployee(employee);  // Update existing employee
                //}

                return RedirectToAction("Index");  // Redirect to employee list after submission
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