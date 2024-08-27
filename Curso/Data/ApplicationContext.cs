using CursoEFCore.Data.Configurations;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace CursoEFCore.Data
{
  public class ApplicationContext : DbContext
  {
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder
      .LogTo(Console.WriteLine, LogLevel.Information)
      .UseSqlServer("Server=dsis.fieb.local\\dev;Database=Curso_EFCore_Camila;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

      MapearPropriedadesEsquecidas(modelBuilder);
    }

    private void MapearPropriedadesEsquecidas(ModelBuilder modelBuilder)
    {
      foreach (var entity in modelBuilder.Model.GetEntityTypes())
      {
        var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

        foreach (var property in properties)
        {
          if (string.IsNullOrEmpty(property.GetColumnType())
          && !property.GetMaxLength().HasValue)
          {
            // property.SetMaxLength(100);
            property.SetColumnType("VARCHAR(100)");

          };
        }
      }
    }
  }
}