using Microsoft.EntityFrameworkCore;
using EmpManager.Models;
using System.Collections.Generic;

namespace EmpManager.Data
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

            public DbSet<Employee> Employees { get; set; }
        }
    }

