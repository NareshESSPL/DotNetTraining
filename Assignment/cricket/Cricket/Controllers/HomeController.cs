using System.Diagnostics;
using Cricket.Models;
using HELP;
using MAIN;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Cricket.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        private readonly cricketdal _cricketDal;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration; // Fixed initialization of _configuration
            _cricketDal = new cricketdal(_configuration.GetConnectionString("ConString"));
        }

        public IActionResult Index()
        {
            var player = _cricketDal.GetPlayers(0); // No change needed here
            return View(player);
        }

        [HttpGet]
        public IActionResult AddPlayer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPlayer(helpp player)
        {
            if (ModelState.IsValid)
            {
                _cricketDal.AddPlayer(player);
                return RedirectToAction("Index");
            }
            return View(player);
        }

        [HttpGet]
        public IActionResult EditPlayer(int id)
        {
            var player = _cricketDal.GetPlayers(0).FirstOrDefault(p => p.PlayerId == id); // Fixed by passing required argument 'v' to GetPlayers
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        [HttpPost]
        public IActionResult EditPlayer(helpp player)
        {
            if (ModelState.IsValid)
            {
                _cricketDal.UpdatePlayer(player);
                return RedirectToAction("Index");
            }
            return View(player);
        }

        [HttpGet]
        public IActionResult DeletePlayer(int id)
        {
            var player = _cricketDal.GetPlayers(0).FirstOrDefault(p => p.PlayerId == id); // Fixed by passing required argument 'v' to GetPlayers
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        [HttpPost]
        public IActionResult DeletePlayerConfirmed(int id)
        {
            _cricketDal.DeletePlayer(id);
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
