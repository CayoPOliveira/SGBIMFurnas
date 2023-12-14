using Microsoft.EntityFrameworkCore;
using SGBIMFurnas.Models;

namespace SGBIMFurnas.Data;

public class EtapaContext : DbContext
{
    public EtapaContext(DbContextOptions<EtapaContext> opts) : base(opts)
    {
    }

    public DbSet<Etapa> Etapas { get; set; }
}
