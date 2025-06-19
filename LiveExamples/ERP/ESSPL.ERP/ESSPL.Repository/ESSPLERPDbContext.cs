using ESSPL.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESSPL.Repository
{
    public class ESSPLERPDbContext : DbContext
    {
        public ESSPLERPDbContext(DbContextOptions<ESSPLERPDbContext> options)
        : base(options)
        {
        }

        public DbSet<ESSPLUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Device> Devices { get; set; }

        //https://learn.microsoft.com/en-us/ef/core/modeling/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserID);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleID);

            modelBuilder.Entity<Device>()
                .HasOne(r => r.User)
                .WithMany(r => r.Devices)
                .HasForeignKey(ur => ur.UserID);

            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<Device>().ToTable("LoggedInDevice");
        }
    }
}
