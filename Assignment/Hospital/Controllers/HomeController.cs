using System.Diagnostics;
using head;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using support;  // assuming 'main' class for DAL is here

namespace Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        private readonly PatientDal _PatientDal;  // DAL instance

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _PatientDal = new PatientDal(_configuration.GetConnectionString("ConString"));  // Correct connection string
        }

        public IActionResult Index()
        {
            var patients = _PatientDal.GetPatients(0); // Pass a default ID value, e.g., 0  
            return View(patients); // Pass the strongly-typed model  
        }



        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(help patient)
        {
            if (patient.Document != null && patient.Document.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(patient.Document.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    patient.Document.CopyTo(fileStream);
                }

                // Save relative path
                patient.DocumentPath = "/uploads/" + uniqueFileName;
            }

            _PatientDal.AddPatient(patient); // insert into DB
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult EditPatient(int id)
        {
             
            return View();
        }

        [HttpPost]
        public IActionResult EditPatient(help patient)
        {
            if (ModelState.IsValid)
            {
                _PatientDal.EditPatient(patient);  // Update existing patient
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        [HttpGet]
        public IActionResult DeletePatient(int id)
        {
            var patient = _PatientDal.GetPatients(id);
            if (patient == null)
            {
                return NotFound();
            }

            _PatientDal.DeletePatient(id);  // Delete by ID
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
