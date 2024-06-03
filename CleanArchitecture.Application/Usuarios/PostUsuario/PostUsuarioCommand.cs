using CleanArchitecture.Application.Abstraction.Handlers;
using CleanArchitecture.Application.Usuarios.Shared;

namespace CleanArchitecture.Application.Usuarios.PostUsuario;

public sealed record PostUsuarioCommand(
    UsuarioRequest Usuario)
    : ICommand<UsuarioResponse>;
