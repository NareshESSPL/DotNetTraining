using System.Diagnostics;
using data_fIRSTTT.Models;
using Microsoft.AspNetCore.Mvc;

namespace data_fIRSTTT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentContext context;
        public HomeController(ILogger<HomeController> logger, StudentContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            List<Student>st=context.Students.ToList();
            return View(st);
        }
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Student st = context.Students.FirstOrDefault(item => item.Id == id);
                if (st != null)
                {
                    return View(st);
                }
                else
                {
                    TempData["message"] = "Record not Found :" + id;
                    return RedirectToAction("List");
                }
            }
            TempData["message"] = "Record not Found :" + id;
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Student s=context.Students.FirstOrDefault(item=>item.Id == id);
                if (s != null)
                {
                    return View(s);
                }
                else
                {
                    TempData["message"] = "Unable to Find the Record:"+id;
                    return RedirectToAction("List");
                }
            }
            TempData["message"] = "Please Pass Id to edit the Data";
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Edit(Student s)
        {
            if (ModelState.IsValid)
            {
                context.Students.Update(s);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(s);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Student s = context.Students.FirstOrDefault(item => item.Id == id);
                if (s != null)
                {
                    return View(s);
                }
                else
                {
                    TempData["message"] = "Unable to Delete the Record:" + id;
                    return RedirectToAction("List");
                }
            }
            TempData["message"] = "Insert the id For Deletion";
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Delete(Student s)
        {
            if (ModelState.IsValid)
            {
                context.Students.Remove(s);
                context.SaveChanges();
                TempData["message"] = "Data is Deleted here";
                return RedirectToAction("List");
            }
            TempData["message"] = "Unable to Delete the Record";
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student str)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(str);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(str);

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
