using AutonomousParkingApp.StorageCarNumbers.DB.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace AutonomousParkingApp.StorageCarNumbers.DB.Contexts;

public class StorageCarNumbersContext : DbContext 
{
    private readonly string urlDbServer;

    public DbSet<ParkingEntity> Parkings { get; set; }
    
    public DbSet<ReservationEntity> Reservations { get; set; }

    public StorageCarNumbersContext(IConfiguration сonfiguration, bool isCreate = false)
    {
        urlDbServer = сonfiguration.GetConnectionString(Constants.DbStorageCarNumbers)!;

        if(isCreate)
            Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(urlDbServer);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParkingEntity>()
            .Property(x => x.Id)
            .HasDefaultValueSql("NEWID()");

        modelBuilder.Entity<ReservationEntity>()
            .Property(x => x.Id)
            .HasDefaultValueSql("NEWID()");
    }
}
