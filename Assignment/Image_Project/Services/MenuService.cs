using Image_Project;
using Image_Project.Models;
using Image_Project.Models.Data;
using Microsoft.EntityFrameworkCore;
namespace Image_Project.Services
{

    public class MenuService : IMenuService
    {
        private readonly ApplicationDbContext _context;

        public MenuService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Menu>> GetMenusAsync()
        {
            return await _context.Menus.ToListAsync();
        }
    }
}
