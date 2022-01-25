using Microsoft.EntityFrameworkCore;
using PawsClaws.Data.Models;

namespace PawsClaws.Data;
public class PawsAndClawsContext : DbContext
{
    public PawsAndClawsContext()
    {
    }

    public PawsAndClawsContext(DbContextOptions<PawsAndClawsContext> options)
        : base(options)
    {
        this.Database.EnsureCreated();
        DbInitializer.Initialize(this);
    }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Pet> Pets { get; set; }

    public string DbPath { get; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>().ToTable("Appointment");
        modelBuilder.Entity<Customer>().ToTable("Customer");
        modelBuilder.Entity<Pet>().ToTable("Pet");
    }
}
