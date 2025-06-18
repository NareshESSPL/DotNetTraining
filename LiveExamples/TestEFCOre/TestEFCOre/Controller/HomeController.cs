using Microsoft.AspNetCore.Mvc;
using TestEFCore.Repository;

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
             var users = _testEFCoreDbContext.User.ToList();

            return View(users);
        }
    }
}
