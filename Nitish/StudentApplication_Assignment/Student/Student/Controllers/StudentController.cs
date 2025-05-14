using Microsoft.AspNetCore.Mvc;
using DataLayer;
using DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Student.Controllers
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
            var StudentsData =  _studentDAL.GetStudentData();
            return View(StudentsData);
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



        public ActionResult Submit(Students obj)
        {
            ModelState.Remove("StudentId");
            ModelState.Remove("AddmissionDate");
            if (ModelState.IsValid)
            {

                _studentDAL.AddStudentInDB (obj);
                return RedirectToAction("Index"); // Redirect to the list of employee
            }

            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem("Male", "1"));
            gender.Add(new SelectListItem("Female", "2"));
            gender.Add(new SelectListItem("Others", "3"));

            ViewData["Gender"] = gender;

            return View("Create",obj); // If model is invalid, return the form with errors
        }

        public IActionResult Edit(int id)
        {
            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem("Male", "1"));
            gender.Add(new SelectListItem("Female", "2"));
            gender.Add(new SelectListItem("Others", "3"));

            ViewData["Gender"] = gender;

            var student = _studentDAL.GetStudentData(id);
            return View("Create", student);
        }

        public IActionResult Delete(int id)
        {
            
            _studentDAL.DeleteFromDB(id);
            return RedirectToAction("Index");
        }
    }
}
