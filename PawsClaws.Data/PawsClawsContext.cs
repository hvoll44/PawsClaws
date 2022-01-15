using Microsoft.EntityFrameworkCore;
using PawsClaws.Data.Models;

namespace PawsClaws.Data;
public class PawsClawsContext : DbContext
{
    public DbSet<AppointmentDto> Appointments { get; set; }
    public DbSet<CustomerDto> Customers { get; set; }
    public DbSet<PetDto> Pets { get; set; }

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
        modelBuilder.Entity<AppointmentDto>().ToTable("Appointment");
        modelBuilder.Entity<CustomerDto>().ToTable("Customer");
        modelBuilder.Entity<PetDto>().ToTable("Pet");
    }
}
