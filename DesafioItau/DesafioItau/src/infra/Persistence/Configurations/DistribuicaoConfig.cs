using DesafioItau.src.Domain.Distribuicoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioItau.src.Infrastructure.Persistence.Configurations
{
    public class DistribuicaoConfig : IEntityTypeConfiguration<Distribuicao>
    {
        public void Configure(EntityTypeBuilder<Distribuicao> builder)
        {
            builder.ToTable("Distribuicoes");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.OrdemCompraId)
                .IsRequired();

            builder.Property(d => d.CustodiaFilhoteId)
                .IsRequired();

            builder.Property(d => d.Ticker)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(d => d.Quantidade)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(d => d.PrecoUnitario)
                .HasColumnType("decimal(18,4)")
                .IsRequired();

            builder.Property(d => d.DataDistribuicao)
                .IsRequired();

            builder.HasIndex(d => d.OrdemCompraId);
            builder.HasIndex(d => d.CustodiaFilhoteId);
        }
    }
}
