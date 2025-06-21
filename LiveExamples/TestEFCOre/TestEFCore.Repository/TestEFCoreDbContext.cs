using Microsoft.EntityFrameworkCore;
using System;
using TestEFCore.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //If you are not using DI and initailize the connection
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("YourConnectionStringHere");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Shadow property
            //modelBuilder.Entity<ESSPLUser>()
            //        .Property<DateTime>("ModifiedBy"); 

            //You can define a global filter in your DbContext:
            //Now every query on User will automatically exclude InActive records.
            //modelBuilder.Entity<ESSPLUser>().HasQueryFilter(p => !p.IsActive);

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
