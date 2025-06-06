
using Microsoft.EntityFrameworkCore;
using IImage_Uploadd.Models;

namespace IImage_Uploadd.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) {
        
           }
        public DbSet<Student>Studentss { get; set; }
    }
}
