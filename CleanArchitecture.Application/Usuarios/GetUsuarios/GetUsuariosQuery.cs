using CleanArchitecture.Application.Abstraction.Handlers;

namespace CleanArchitecture.Application.Usuarios.GetUsuarios;

public sealed record GetUsuariosQuery()
    : IQuery<IEnumerable<UsuarioResponse>>;
