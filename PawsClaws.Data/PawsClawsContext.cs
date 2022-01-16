using Microsoft.EntityFrameworkCore;
using PawsClaws.Data.Models;

namespace PawsClaws.Data;
public class PawsClawsContext : DbContext
{
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Pet> Pets { get; set; }

    public string DbPath { get; }

    public PawsClawsContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "pawsclaws.db");
    }

    // The following configures EF to create a Sql server database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>().ToTable("Appointment");
        modelBuilder.Entity<Customer>().ToTable("Customer");
        modelBuilder.Entity<Pet>().ToTable("Pet");
    }
}
