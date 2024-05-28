using CleanArchitecture.Application.Usuarios;
using CleanArchitecture.Domain.Usuarios;

namespace CleanArchitecture.Application.Extensions;

// Como a Classe não possui tantos atributos, aqui pode ser feito o 'Request > Entity' e 'Entity > Response'.
// Caso a classe possua muitos atributos ou 'filhos / arrays', é recomendado criar uma classe de extensão para cada conversão.

internal static class UsuarioExtension
{
    public static UsuarioResponse ToResponse(
        this Usuario usuario)
    {
        // Converte um objeto de domínio para um objeto de resposta.

        return new UsuarioResponse() 
        {
            Nome = usuario.Nome,
            Idade = usuario.Idade,
            Email = usuario.Email,
            Senha = usuario.Senha,
            Admin = usuario.Admin
        };
    }
}
