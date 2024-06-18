using CleanArchitecture.Domain.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configuration;

internal sealed class ProdutoConfiguration
    : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("tbPROD");

        builder.HasKey(u => u.Id).HasName("PROD_01");

        builder.HasQueryFilter(x => x.RegDel == ProdutoId.Zero);

        builder.Property(u => u.Id)
            .HasConversion(id => id.Value, value => new ProdutoId(value))
            .IsRequired()
            .HasColumnType("int")
            .HasColumnName("PROD_Id")
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Nome)
            .HasColumnName("PROD_Nome")
            .HasColumnType<string>("varchar(150)")
            .IsRequired();

        builder.Property(u => u.Descrição)
            .HasColumnName("PROD_Descrição")
            .HasColumnType<string>("varchar(500)")
            .IsRequired();

        builder.Property(u => u.Cor)
            .HasColumnName("PROD_Cor")
            .HasColumnType<string?>("varchar(50)");

        builder.Property(u => u.Marca)
            .HasColumnName("PROD_Marca")
            .HasColumnType<string?>("varchar(50)");

        builder.Property(u => u.Garantia)
            .HasColumnName("PROD_Garantia")
            .HasColumnType<bool>("bit")
            .IsRequired();

        builder.Property(u => u.CreatedOn)
            .IsRequired()
            .HasColumnType<DateTime>("datetime")
            .HasColumnName("PROD_CreatedOn");

        builder.Property(u => u.UpdatedOn)
            .IsRequired()
            .HasColumnType<DateTime>("datetime")
            .HasColumnName("PROD_UpdatedOn");

        builder.Property(u => u.RegDel)
            .HasConversion(id => id.Value, value => new ProdutoId(value))
            .IsRequired()
            .HasColumnType("int")
            .HasColumnName("PROD_RegDel");
    }
}
