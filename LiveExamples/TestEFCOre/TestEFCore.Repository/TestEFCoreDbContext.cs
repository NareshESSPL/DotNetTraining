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
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreign key
            modelBuilder.Entity<Device>()
              .HasOne(d => d.User)
              .WithMany(u => u.Devices)
              .HasForeignKey(d => d.UserID);

            modelBuilder.Entity<Device>()
                  .HasKey(b => b.DeviceID);

            modelBuilder.Entity<UserRole>()
              .HasOne(d => d.User)
              .WithMany(u => u.UserRoles)
              .HasForeignKey(d => d.UserID);

            modelBuilder.Entity<UserRole>()
              .HasOne(d => d.Role)
              .WithMany(u => u.UserRoles)
              .HasForeignKey(d => d.RoleID);

        }
    }
}
