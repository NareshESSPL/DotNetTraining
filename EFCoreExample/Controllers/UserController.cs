using EFCoreExample.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var users = await _context.User.ToListAsync();
        //    return View(users);
        //}

        public IActionResult Index()
        {
            var users =  _context.User.ToList();
            return View(users);
            
        }
    }
}
