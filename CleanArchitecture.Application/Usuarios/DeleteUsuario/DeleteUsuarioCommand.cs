using CleanArchitecture.Application.Abstraction.Handlers;

namespace CleanArchitecture.Application.Usuarios.DeleteUsuario;

public sealed record DeleteUsuarioCommand(
    Guid UsuarioId)
    : ICommand<int>;

