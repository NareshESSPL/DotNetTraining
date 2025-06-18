using System.Diagnostics;
using Efcore.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Entity;

namespace Efcore.Controllers
{
    

    namespace TestEFCore
    {
        public class HomeController : Controller
        {
            private TestEFCoreDbContext _testEFCoreDbContext { get; set; }

            public HomeController(TestEFCoreDbContext testEFCoreDbContext)
            {
                _testEFCoreDbContext = testEFCoreDbContext;
            }

            public IActionResult Index()
            {
                var users = _testEFCoreDbContext.Users.ToList();

                return View(users);
            }
        }
    }
}
