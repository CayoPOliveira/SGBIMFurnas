using Microsoft.EntityFrameworkCore;
using SGBIMFurnas.Models;

namespace SGBIMFurnas.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
    {
    }

    public DbSet<Etapa> Etapas { get; set; }
    public DbSet<Cargo> Cargos { get; set; }

}
