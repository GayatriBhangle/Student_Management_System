using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LabPractice.Models;

public partial class LabDbContext : DbContext
{
    public LabDbContext()
    {
    }

    public LabDbContext(DbContextOptions<LabDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=LabDb;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emp>(entity =>
        {
            entity.HasKey(e => e.No).HasName("PK__Emp__3214D4A89605119E");

            entity.ToTable("Emp");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC070E220E0D");

            entity.Property(e => e.Course)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
