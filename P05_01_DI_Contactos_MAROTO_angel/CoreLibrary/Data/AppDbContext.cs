using CoreLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreLibrary.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasKey(department => department.Name);

        modelBuilder.Entity<Employee>().HasKey(employee => employee.Dni);

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(emloyee => emloyee.Dni)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(employee => employee.Department)
            .WithMany(department => department.ListEmployees)
            .HasForeignKey(employee => employee.DepartmentName);
            //.IsRequired(false);
        });
    }
}

