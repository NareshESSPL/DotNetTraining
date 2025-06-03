using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestAppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger, TestAppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()//add this line of code
        {
            List<Student> st=_appDbContext.Students.ToList();
            return View(st);
        }
        [HttpGet]
        public IActionResult Create()//add get 
        {
            return View();
   
        }
        [HttpPost]
        public IActionResult Create(Student s)//add get  pass student model with object s
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Students.Add(s);
                _appDbContext.SaveChanges();
                return RedirectToAction("List");
            }
            return View(s);

        }
        [HttpGet]
        public IActionResult Edit(int? id)//add get 
        {
            if (id != null)
            {
                Student s = _appDbContext.Students.FirstOrDefault(item => item.Id == id);
                if (s != null)
                {
                    return View(s);
                }
                else
                {
                    return RedirectToAction("List");
                }
               
            }

           return RedirectToAction("List");

        }
        [HttpPost]
        public IActionResult Edit(Student s)//add get  pass student model with object s
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Students.Update(s);
                _appDbContext.SaveChanges();
                return RedirectToAction("List");
            }
            return View(s);

        }
        [HttpGet]
        public IActionResult Delete(int? id)//add get 
        {
            if (id != null)
            {
                Student s = _appDbContext.Students.FirstOrDefault(item => item.Id == id);
                if (s != null)
                {
                    return View(s);
                }
                else
                {
                    return RedirectToAction("List");
                }

            }

            return RedirectToAction("List");

        }
        [HttpPost]
        public IActionResult Delete(Student s)//add get  pass student model with object s
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Students.Remove(s);
                _appDbContext.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("List");

        }
         
        [HttpGet]
        public IActionResult Details(int? id)//add get 
        {
            if (id != null)
            {
                Student s = _appDbContext.Students.FirstOrDefault(item => item.Id == id);
                if (s != null)
                {
                    return View(s);
                }
                else
                {
                    return RedirectToAction("List");
                }

            }

            return RedirectToAction("List");

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
