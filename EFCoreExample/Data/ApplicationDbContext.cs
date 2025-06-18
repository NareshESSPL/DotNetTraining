using System.Collections.Generic;
using EFCoreExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
    }
}
