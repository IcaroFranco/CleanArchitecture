using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Usuarios;

public static class UsuarioErrors
{
    public static readonly Error NotFound = new(
        "Usuario.NotFound",
        "Usuario(s) não foi encontrado.");
    
    public static readonly Error Unauthorized = new(
        "Usuario.Unauthorized",
        "Usuario informado não possui permissão ou não existe.");
    
    public static readonly Error BadRequest = new(
        "Usuario.BadRequest",
        "Usuario informado não está de acordo com as especifícações.");
}
