using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Usuarios;

public sealed class Usuario
    : Entity<UsuarioId>
{
    public Usuario() { }

    public Usuario(
        string nome,
        int idade,
        string email,
        string senha,
        bool admin,
        DateTime utcNow) : base(utcNow)
    {
        Nome = nome;
        Idade = idade;
        Email = email;
        Senha = senha;
        Admin = admin;
    }

    public string Nome { get; private set; } = null!;

    public int Idade { get; private set; }

    public string? Email { get; private set; } = null!;

    public string Senha { get; private set; } = null!;
    
    public bool Admin { get; private set; }

    protected override UsuarioId GetZeroValue()
        => UsuarioId.Zero;

    public static Usuario Criar(
        string? nome, 
        int? idade, 
        string? email, 
        string? senha, 
        bool? admin,
        DateTime utcNow)
    {
        return new Usuario(
            nome ?? "Não informado.", 
            idade ?? 0, 
            email ?? "Não informado", 
            senha ?? "Teste@123", 
            admin ?? false, 
            utcNow);
    }
}
