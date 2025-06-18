using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmpManager.Data;
using EmpManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpManager.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employees { get; set; } = new List<Employee>();

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees.ToListAsync();
        }
    }
}
