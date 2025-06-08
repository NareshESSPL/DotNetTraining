using MANE;
using Microsoft.AspNetCore.Mvc;
using SPRT;

namespace SHOES.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CustomerDal _dal;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _dal = new CustomerDal(configuration.GetConnectionString("ConString"));
        }

        public IActionResult Index()
        {
            var customer = _dal.GetCustomers();
            return View(customer);
        }

        [HttpGet]
        public IActionResult AddCustomer() => View();

        [HttpPost]
        public IActionResult AddCustomer(help customer)
        {
            if (ModelState.IsValid)
            {
                _dal.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var customer = _dal.GetCustomerById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(help customer)
        {
            if (ModelState.IsValid)
            {
                _dal.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _dal.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer); // Pass the customer to the view
        }


        [HttpPost]
       
        public IActionResult DeleteCustomer(help customer)
        {
            _dal.DeleteCustomer(customer.CustomerId);
            return RedirectToAction("Index");
        }

    }
}
