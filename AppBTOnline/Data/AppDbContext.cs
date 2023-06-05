using Microsoft.EntityFrameworkCore;
using AppBTOnline.Models;

namespace AppBTOnline.Data;

public class AppDbContext : DbContext
{
    public DbSet<Player> jugadores{ get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aquí puedes configurar la estructura y relaciones de tus entidades
        // utilizando Fluent API o atributos de anotación.
        // Por ejemplo:
        modelBuilder.Entity<Player>().Property(p => p.Name).IsRequired();
        modelBuilder.Entity<Player>().Property(p => p.Apellidos).IsRequired();
        modelBuilder.Entity<Player>().Property(p => p.CentroEducativo).IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = Constants.DatabasePath;

            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 33))); // Habilitar resiliencia ante errores transitorios
        }
    }

}