using AutonomousParkingApp.Authentication.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace AutonomousParkingApp.Authentication.DB.Contexts;

public class AuthContext : DbContext
{
    private readonly string urlDbServer;

    public DbSet<UserEntity> Users { get; set; }

    public AuthContext(IConfiguration configuration, bool isCreate = false)
    {
        urlDbServer = configuration.GetConnectionString(Constants.DbAuth)!;

        if (isCreate)
            Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
         optionsBuilder.UseSqlServer(urlDbServer);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .Property(x => x.Id)
            .HasDefaultValueSql("NEWID()");
    }
}
