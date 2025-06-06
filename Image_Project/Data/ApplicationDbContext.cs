using Image_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Image_Project.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().ToTable("Menu");
        }

        public DbSet<ImageUpload> ImageUploads { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}
