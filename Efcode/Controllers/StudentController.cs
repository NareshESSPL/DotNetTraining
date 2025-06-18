using Efcode.Data;
using Microsoft.AspNetCore.Mvc;

namespace Efcode.Controllers
{
    public class StudentController : Controller
    {    
        private readonly AppDbContext _appDbContext;
        public StudentController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {  
            var users = _appDbContext.students.ToList();
            return View(users);
        }
    }
}
