using Microsoft.EntityFrameworkCore;
using InvoiceApp.Models;

namespace InvoiceApp.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; } = null;
    }
}
