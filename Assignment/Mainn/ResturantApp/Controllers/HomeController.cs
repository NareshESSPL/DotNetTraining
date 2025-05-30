using System.Diagnostics;
using Help;
using Microsoft.AspNetCore.Mvc;
using ResturantApp.Models;

namespace ResturantApp.Controllers
{
    public class HomeController : Controller
    {
        private static List<hey> _customers = new List<hey>();

        public IActionResult Index()
        {
            return View(_customers);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(hey customer)
        {
            if (ModelState.IsValid)
            {
                // Ensure OrderId is unique before adding
                //if (_customers.Any(c => c.OrderId == customer.OrderId))
                //{
                //    ModelState.AddModelError("OrderId", "OrderId must be unique.");
                //    return View(customer);
                //}

                _customers.Add(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult UpdateCustomer(string orderId)
        {
            var customer = _customers.FirstOrDefault(c => c.OrderId == orderId);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(hey customer)
        {
            if (ModelState.IsValid)
            {
                var existingCustomer = _customers.FirstOrDefault(c => c.OrderId == customer.OrderId);
                if (existingCustomer != null)
                {
                    existingCustomer.Name = customer.Name;
                    existingCustomer.Age = customer.Age;
                    existingCustomer.Address = customer.Address;
                }
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public IActionResult DeleteCustomer(string orderId)
        {
            var customer = _customers.FirstOrDefault(c => c.OrderId == orderId);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
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
