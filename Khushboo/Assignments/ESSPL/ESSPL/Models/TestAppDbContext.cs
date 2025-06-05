using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ESSPL.Models;

public partial class TestAppDbContext : DbContext
{
    public TestAppDbContext()
    {
    }

    public TestAppDbContext(DbContextOptions<TestAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Help> Helps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }//remove connection method becoz already added in appjson file

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Help>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Help__3214EC07F1396AAF");

            entity.ToTable("Help");

            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.DocumentPath).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
