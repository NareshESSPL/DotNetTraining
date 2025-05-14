using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.DTO;
using DataLayer;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        //simulating a database using a static list , so here static can be accessed by every method 
        private static readonly List<Person> People = new List<Person>();

        //{
        //    new Person
        //{
        //    Id = 1,
        //    Name = "Alice Johnson",
        //    Age = 28,
        //    Email = "alice.johnson@example.com",
        //    Password = "AlicePass123",
        //    SelectedGender = "2" // Female
        //},

        //new Person
        //{
        //    Id = 2,
        //    Name = "Bob Smith",
        //    Age = 35,
        //    Email = "bob.smith@example.com",
        //    Password = "BobSecure456",
        //    SelectedGender = "1" // Male
        //},

        //new Person
        //{
        //    Id = 3,
        //    Name = "Charlie Davis",
        //    Age = 22,
        //    Email = "charlie.davis@example.com",
        //    Password = "CharliePwd789",
        //    SelectedGender = "3" // Other/Custom
        //}
        //};


        //to get page : Person/Create
        public ActionResult Create()
        {
            return View();// return a from to create a new person
        }

        public ActionResult Submit(Person person)
        {
            if (ModelState.IsValid)
            {
                People.Add(person);// adding new person to list
                return RedirectToAction("Index");// redirecting to the person list
            }
            return View("Create",person);// if model is invalid then return form with erros
        }



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {   // or we can add here     
            // return View(People);
            PersonsDAL obj = new PersonsDAL();

            var persons = obj.GetPersons();

            return View(persons);

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
