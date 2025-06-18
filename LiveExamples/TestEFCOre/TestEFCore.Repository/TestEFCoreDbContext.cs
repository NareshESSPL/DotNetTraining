using Microsoft.EntityFrameworkCore;
using TestEFCore.Entity;

namespace TestEFCore.Repository
{
    public class TestEFCoreDbContext : DbContext
    {
        public TestEFCoreDbContext(DbContextOptions<TestEFCoreDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> User { get; set; }

    }
}
