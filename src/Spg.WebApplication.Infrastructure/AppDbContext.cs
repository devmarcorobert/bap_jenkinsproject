using Microsoft.EntityFrameworkCore;
using Bogus; 
using Spg.WebApplication.AdministrationApp.Domain;

namespace Spg.WebApplication.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Class> Classes => Set<Class>();
    public DbSet<Address> Addresses => Set<Address>();
    
    public AppDbContext(DbContextOptions options) : base(options)
    {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=AdminApp.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.Address)
            .WithMany(a => a.Teachers);
        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.Classes)
            .WithMany(c => c.Teachers);
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.DepartmentNavigation)
            .WithOne(d => d.DepartmentDirector)
            .HasForeignKey<Department>(b => b.TeacherId);
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Address)
            .WithMany(a => a.Students);
        modelBuilder.Entity<Student>()
            .HasOne(s => s.ClassNavigation)
            .WithMany(c => c.Students);
        modelBuilder.Entity<Room>()
            .HasOne(r=> r.DepartmentNavigation)
            .WithMany(d => d.Rooms);
    }

   
}