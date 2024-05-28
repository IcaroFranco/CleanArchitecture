namespace CleanArchitecture.Domain.Usuarios;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByIdAsync(
        UsuarioId usuarioId,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<Usuario>> GetAllAsync(
        CancellationToken cancellationToken = default);

    void Add(Usuario usuario);
}
