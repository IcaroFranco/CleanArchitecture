namespace CleanArchitecture.Domain.Usuarios;

public sealed record UsuarioId(Guid Value)
{
    public static UsuarioId From(Guid value) => new(value);

    public static UsuarioId Zero => new(Guid.Empty);
}
