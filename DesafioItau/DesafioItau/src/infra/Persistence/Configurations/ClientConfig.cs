using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DesafioItau.src.Domain.Clientes.Entities;

namespace DesafioItau.src.Infrastructure.Persistence.Configurations
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            builder.HasIndex(c => c.Cpf)
                .IsUnique();

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.ValorMensal)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Ativo)
                .HasDefaultValue(true);

            builder.Property(c => c.DataAdesao)
                .IsRequired();
        }
    }
}