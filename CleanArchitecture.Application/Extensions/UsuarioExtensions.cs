using CleanArchitecture.Application.Usuarios;
using CleanArchitecture.Application.Usuarios.Shared;
using CleanArchitecture.Domain.Usuarios;

namespace CleanArchitecture.Application.Extensions;

// Como a Classe não possui tantos atributos, aqui pode ser feito o 'Request > Entity' e 'Entity > Response'.
// Caso a classe possua muitos atributos ou 'filhos / arrays', é recomendado criar uma classe de extensão para cada conversão.

internal static class UsuarioExtensions
{
    public static UsuarioResponse ToResponse(
        this Usuario usuario)
    {
        // Converte um objeto de domínio para um objeto de resposta.

        return new UsuarioResponse() 
        {
            Id = usuario.Id.Value,
            Nome = usuario.Nome,
            Idade = usuario.Idade,
            Email = usuario.Email,
            Senha = usuario.Senha,
            Admin = usuario.Admin
        };
    }

    public static Usuario ToEntity(
        this UsuarioRequest request,
        DateTime utcNow)
    {
        // Converte um objeto de requisição para um objeto de domínio.

        return Usuario.Criar(
            request.Nome,
            request.Idade,
            request.Email,
            request.Senha,
            request.Admin,
            utcNow);
    }
}
