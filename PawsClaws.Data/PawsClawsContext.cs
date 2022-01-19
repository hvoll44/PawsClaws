using Microsoft.EntityFrameworkCore;
using PawsClaws.Data.Models;

namespace PawsClaws.Data;
public class PawsClawsContext : DbContext
{
    public PawsClawsContext()
    {
    }

    public PawsClawsContext(DbContextOptions<PawsClawsContext> options)
        : base(options)
    {
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
