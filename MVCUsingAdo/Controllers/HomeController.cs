using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCUsingAdo.Models;

namespace MVCUsingAdo.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly StudentDal dal;
        public HomeController()
        {
            dal = new StudentDal();
        }



        public IActionResult Index()
        {
            List<Student> emps = dal.getEmployees();
            return View(emps);
        }

        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult create(Student emp)
        {
            try
            {
                dal.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            Student emp = dal.getEmployeeByid(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Student emp)
        {
            try
            {
                dal.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult Details(int id)
        {
            Student emp = dal.getEmployeeByid(id);
            return View(emp);
        }
        public IActionResult Delete(int id)
        {
            Student emp = dal.getEmployeeByid(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(Student emp)
        {
            try
            {
                dal.DeleteEmployee(emp.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
