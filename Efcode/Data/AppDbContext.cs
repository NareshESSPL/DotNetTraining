using Efcode.Models;
using Microsoft.EntityFrameworkCore;

namespace Efcode.Data
{
    public class AppDbContext:DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        {

        }
        public DbSet<Student> students { get; set; }
    }
}
