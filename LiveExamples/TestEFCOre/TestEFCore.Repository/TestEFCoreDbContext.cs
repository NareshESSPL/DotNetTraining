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

        public DbSet<ESSPLUser> User { get; set; }
        public DbSet<Device> Device { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreign key
            modelBuilder.Entity<Device>()
              .HasOne(d => d.User)
              .WithMany(u => u.Devices)
              .HasForeignKey(d => d.UserID);

            modelBuilder.Entity<Device>()
                  .HasKey(b => b.DeviceID);                 

        }
    }
}
