namespace CleanArchitecture.Application.Usuarios;

public sealed class UsuarioResponse
{
    public Guid Id { get; init; }

    public required string Nome { get;  init; }

    public int Idade { get; init; }

    public string? Email { get; init; }

    public required string Senha { get; init; }

    public bool Admin { get; init; }
}
