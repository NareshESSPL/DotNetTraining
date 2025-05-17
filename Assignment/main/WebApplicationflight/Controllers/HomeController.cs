using Microsoft.AspNetCore.Mvc;
using main;
using System.Collections.Generic;
using System.Linq;

namespace WebApplicationflight.Controllers
{
    public class HomeController : Controller
    {
        private static List<Traveller> travellers = new List<Traveller>();

        public IActionResult Index()
        {
            return View(travellers);
        }

        [HttpGet]
        public IActionResult AddTraveller()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTraveller(Traveller traveller)
        {
            if (ModelState.IsValid)
            {
                travellers.Add(traveller);
                TempData["SuccessMessage"] = "Traveller added successfully.";
                return RedirectToAction("Index");
            }

            return View(traveller);
        }

        [HttpGet]
        public IActionResult UpdateTraveller(int ticketNo)
        {
            var traveller = travellers.FirstOrDefault(t => t.TicketNo == ticketNo);
            if (traveller == null)
                return NotFound();

            return View(traveller);
        }

        [HttpPost]
        public IActionResult UpdateTraveller(Traveller updatedTraveller)
        {
            var existingTraveller = travellers.FirstOrDefault(t => t.TicketNo == updatedTraveller.TicketNo);
            if (existingTraveller == null)
                return NotFound();

            existingTraveller.Name = updatedTraveller.Name;
            existingTraveller.SeatNo = updatedTraveller.SeatNo;
            existingTraveller.FlightName = updatedTraveller.FlightName;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteTraveller(int ticketNo)
        {
            var traveller = travellers.FirstOrDefault(t => t.TicketNo == ticketNo);
            if (traveller == null)
                return NotFound();

            travellers.Remove(traveller);
            TempData["SuccessMessage"] = "Traveller deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
