using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.DTO;


namespace WebApplication1.Controllers
{

    public class EmployeeController : Controller
    {
        private static readonly List<Employees>Emp = new List<Employees>();

        public ActionResult Create()
        {
            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem("Male","male"));
            gender.Add(new SelectListItem("Female", "female"));
            gender.Add(new SelectListItem( "Others", "others"));

            ViewData["Gender"] = gender;

            return View();// return a from to create a new person
        }

        public IActionResult Index()
        {   

        EmployeesDAL obj2 = new EmployeesDAL();
        var employeelist = obj2.GetEmployeedata();

        return View(employeelist);
        }
        public ActionResult Submit(Employees emp)
        {
            if (ModelState.IsValid)
            {
                if (new EmployeesDAL().GetEmployeedata().Exists(e => e.EmployeeName == emp.EmployeeName))
                {
                    ModelState.AddModelError("EmployeeAge", emp.EmployeeName + " Alreadyyy exists");
                }
                else
                {
                    var obj = new EmployeesDAL();
                    obj.AddEmployees(emp);
                    //Emp.Add(emp);// adding new person to list
                    // return RedirectToAction("Index");// redirecting to the person list

                    return RedirectToAction("Index");
                }
                 List<SelectListItem> gender = new List<SelectListItem>();
                gender.Add(new SelectListItem("Male", "1"));
                gender.Add(new SelectListItem("Female", "2"));
                gender.Add(new SelectListItem("Others", "3"));

            ViewData["Gender"] = gender;
               
            }
            return View("Create", emp);// if model is invalid then return form with erros
        }

    }
}
