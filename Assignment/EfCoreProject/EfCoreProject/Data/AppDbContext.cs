using EfCoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
       
    }
}
