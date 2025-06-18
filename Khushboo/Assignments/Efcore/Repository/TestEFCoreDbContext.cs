using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class TestEFCoreDbContext : DbContext
    {
        public TestEFCoreDbContext(DbContextOptions<TestEFCoreDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users{ get; set; }

    }
}
