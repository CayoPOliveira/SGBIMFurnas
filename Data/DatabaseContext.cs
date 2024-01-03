using Microsoft.EntityFrameworkCore;
using SGBIMFurnas.Models;

namespace SGBIMFurnas.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fase -> Etapa
        modelBuilder.Entity<Fase>()
            .HasOne(fase => fase.Etapa)
            .WithMany(etapa => etapa.Fases)
            .HasForeignKey(fase => fase.EtapaId);

        // FaseTransicao -> Fase
        modelBuilder.Entity<FaseTransicao>()
            .HasKey(transicao => new {transicao.FaseAnteriorId, transicao.FaseSeguinteId});

        modelBuilder.Entity<FaseTransicao>()
           .HasOne(transicao => transicao.FaseAnterior)
           .WithMany(fase => fase.FasesSeguintes)
           .HasForeignKey(transicao => transicao.FaseAnteriorId);

        modelBuilder.Entity<FaseTransicao>()
           .HasOne(transicao => transicao.FaseSeguinte)
           .WithMany(fase => fase.FasesAnteriores)
           .HasForeignKey(transicao => transicao.FaseSeguinteId);

        // Tarefas -> Fase
        modelBuilder.Entity<Tarefa>()
            .HasOne(tarefa => tarefa.Fase)
            .WithMany(fase => fase.Tarefas)
            .HasForeignKey(tarefa => tarefa.FaseId);

        modelBuilder.Entity<Tarefa>()
            .HasOne(tarefa => tarefa.TarefaAnterior)
            .WithOne(tarefa => tarefa.TarefaSeguinte)
            .HasForeignKey<Tarefa>(tarefa => tarefa.TarefaAnteriorId)
            .IsRequired(false);
        
    }

    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<Etapa> Etapas { get; set; }
    public DbSet<Fase> Fases { get; set; }
    public DbSet<FaseTransicao> FaseTransicao { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
}
