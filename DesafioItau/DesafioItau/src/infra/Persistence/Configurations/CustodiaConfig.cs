using DesafioItau.src.Domain.Custodias.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioItau.src.Infrastructure.Persistence.Configurations
{
    public class CustodiaConfig : IEntityTypeConfiguration<Custodia>
    {
        public void Configure(EntityTypeBuilder<Custodia> builder)
        {
            builder.ToTable("Custodias");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.ContaGraficaId)
                .IsRequired();

            builder.Property(c => c.Ticker)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.Quantidade)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.PrecoMedio)
                .HasColumnType("decimal(18,4)")
                .IsRequired();

            builder.Property(c => c.DataAtualizacao)
                .HasColumnName("DataUltimaAtualizacao")
                .IsRequired();

            builder.HasOne(c => c.ContaGrafica)
                .WithMany()
                .HasForeignKey(c => c.ContaGraficaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(c => new { c.ContaGraficaId, c.Ticker })
                .IsUnique();
        }
    }
}
