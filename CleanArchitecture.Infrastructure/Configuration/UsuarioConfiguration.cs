using CleanArchitecture.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configuration;

internal sealed class UsuarioConfiguration
    : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        // Eventualmente podem existir outras tabelas de usuários, então é sempre bom ter um controle sobre o nome da tabela com siglas.
        builder.ToTable("tbUSUA");

        builder.HasKey(u => u.Id).HasName("USUA_01");

        builder.HasQueryFilter(x => x.RegDel == UsuarioId.Zero);

        builder.Property(u => u.Id)
            .HasConversion(id => id.Value, value => new UsuarioId(value))
            .IsRequired()
            .HasColumnType("char(36)")
            .HasColumnName("USUA_Id")
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Nome)
            .HasColumnName("USUA_Nome")
            .HasColumnType<string>("varchar(150)")
            .IsRequired();

        builder.Property(u => u.Idade)
            .HasColumnName("USUA_Idade")
            .HasColumnType<int>("int")
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnName("USUA_Email")
            .HasColumnType<string?>("varchar(100)")
            .IsRequired();

        builder.Property(u => u.Senha)
            .HasColumnName("USUA_Senha")
            .HasColumnType<string>("varchar(36)")
            .IsRequired();

        builder.Property(u => u.Admin)
            .HasColumnName("USUA_Admin")
            .HasColumnType<bool>("bit")
            .IsRequired();

        // Aqui ficam os três campos de controle de registro. Sempre irá existir esses campos em todas as tabelas.
        // RegDel sendo o mais importante, pois é o campo que irá controlar se o registro foi deletado ou não.

        builder.Property(u => u.CreatedOn)
            .IsRequired()
            .HasColumnType<DateTime>("datetime")
            .HasColumnName("USUA_CreatedOn");

        builder.Property(u => u.UpdatedOn)
            .IsRequired()
            .HasColumnType<DateTime>("datetime")
            .HasColumnName("USUA_UpdatedOn");

        builder.Property(u => u.RegDel)
            .HasConversion(id => id.Value, value => new UsuarioId(value))
            .IsRequired()
            .HasColumnType("char(36)")
            .HasColumnName("RegDel");
    }
}
