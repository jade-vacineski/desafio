using Microsoft.EntityFrameworkCore;
using DesafioItau.src.Domain.Clientes.Entities;
using DesafioItau.src.Domain.ContasGraficas.entities;
using DesafioItau.src.Domain.Cotacoes;
using DesafioItau.src.Domain.Distribuicoes;
using DesafioItau.src.Domain.Custodias.Entities;

namespace DesafioItau.src.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContaGrafica> ContasGraficas { get; set; }
        public DbSet<Cotacao> Cotacoes { get; set; }
        public DbSet<Distribuicao> Distribuicoes { get; set; }
        public DbSet<Custodia> Custodias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
