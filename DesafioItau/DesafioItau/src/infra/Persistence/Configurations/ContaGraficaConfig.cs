using DesafioItau.src.Domain.Clientes.Entities;
using DesafioItau.src.Domain.ContasGraficas.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioItau.src.Infrastructure.Persistence.Configurations
{
    public class ContaGraficaConfig : IEntityTypeConfiguration<ContaGrafica>
    {
        public void Configure(EntityTypeBuilder<ContaGrafica> builder)
        {
            builder.ToTable("ContasGraficas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.ClienteId)
                .IsRequired();

            builder.Property(c => c.NumeroConta)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasIndex(c => c.NumeroConta)
                .IsUnique();

            builder.Property(c => c.Tipo)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(c => c.DataCriacao)
                .IsRequired();

            builder.HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
