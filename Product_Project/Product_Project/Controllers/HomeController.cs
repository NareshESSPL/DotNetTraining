using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Product_Project.Models;

namespace Product_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppleContext context;

        public HomeController(ILogger<HomeController> logger, AppleContext context)
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
            List<Product> products = context.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            Product p = context.Products.FirstOrDefault(item => item.ProductId == id);
            if (id != null)
            {
                return View(p);  
            }
            else
            {
                TempData["message"] = "Record not Found" + id;
                return RedirectToAction("List");
            }
            TempData["message"] = "Insert Product_Id";
                return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(p);
                context.SaveChanges();
                TempData["message"] = "Product is Added Successfully";
                return RedirectToAction("List");
            }
            
            return View(p);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Product p = context.Products.FirstOrDefault(item => item.ProductId == id);
            if (id != null)
            {
                return View(p);
            }
            else
            {
                TempData["message"] = "Record not Found for:" + id;
                return RedirectToAction("List");
            }
            TempData["message"] = "Pass Product_Id";
            return RedirectToAction("List");

        }
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                context.Products.Update(p);
                context.SaveChanges();
                TempData["message"] = "Updated Succesfully";
                return RedirectToAction("List");
            }
            return View(p);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["message"] = "Product ID not provided.";
                return RedirectToAction("List");
            }

            Product p = context.Products.FirstOrDefault(item => item.ProductId == id);
            if (p == null)
            {
                TempData["message"] = "Product not found for ID: " + id;
                return RedirectToAction("List");
            }

            return View(p);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Product p = context.Products.FirstOrDefault(item => item.ProductId == id);
            if (p != null)
            {
                context.Products.Remove(p);
                context.SaveChanges();
                TempData["message"] = "Product deleted successfully.";
            }
            else
            {
                TempData["message"] = "Delete failed. Product not found.";
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
