using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

namespace SchoolSystem.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
