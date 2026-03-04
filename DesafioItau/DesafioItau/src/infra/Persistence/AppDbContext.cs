using Microsoft.EntityFrameworkCore;
using DesafioItau.src.Domain.Clientes.Entities;
using DesafioItau.src.Domain.ContasGraficas.entities;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
