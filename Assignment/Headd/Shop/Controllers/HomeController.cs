using System.Diagnostics;
using Headd;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shop.Models;
using Sprt;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Customerdal _customerdal;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
            _customerdal = new Customerdal(configuration.GetConnectionString("ConString"));
        }

        // ✅ Display all customers
        public IActionResult Index()
        {
            var customers = _customerdal.AllCustomer;
            return View(customers);
        }

        // ✅ Show Add Form
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        // ✅ Handle Add Form Submit
        [HttpPost]
        public IActionResult AddCustomer(help customer)
        {
            if (customer == null || customer.Document == null || customer.Document.Length == 0)
            {
                ModelState.AddModelError("Document", "Please upload a document.");
                return View(customer);
            }

            string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(customer.Document.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                customer.Document.CopyTo(stream);
            }

            customer.DocumentPath = "/uploads/" + uniqueFileName;
            _customerdal.AddCustomer(customer);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var customer = _customerdal.GetCustomerById(id.Value);
            if (customer == null)
                return NotFound();

            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCustomer(help model)
        {
            if (ModelState.IsValid)
            {
                if (model.Document != null && model.Document.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    string fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Document.FileName);
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.Document.CopyTo(stream);
                    }

                    model.DocumentPath = "/uploads/" + fileName;
                }
                else
                {
                    var existing = _customerdal.GetCustomerById(model.Id);
                    model.DocumentPath = existing?.DocumentPath;
                }

                _customerdal.UpdateCustomer(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }





        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerdal.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Perform the delete
        [HttpPost]
        public IActionResult DeleteCustomerConfirmed(int id)
        {
            _customerdal.DeleteCustomer(id);
            return RedirectToAction("Index");
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
