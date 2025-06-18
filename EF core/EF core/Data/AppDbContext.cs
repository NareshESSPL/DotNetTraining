using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EF_core.Models;

namespace EF_core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; } 
    }
}

