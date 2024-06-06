using CleanArchitecture.Application.Abstraction.Handlers;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Usuarios;

namespace CleanArchitecture.Application.Usuarios.DeleteUsuario;

internal sealed class DeleteUsuarioCommandHandler
    : ICommandHandler<DeleteUsuarioCommand, int>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUsuarioCommandHandler(
        IUsuarioRepository usuarioRepository,
        IUnitOfWork unitOfWork)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
        DeleteUsuarioCommand request,
        CancellationToken cancellationToken)
    {
        var usuarioId = new UsuarioId(request.UsuarioId);

        var usuario = await _usuarioRepository.GetByIdAsync(usuarioId, cancellationToken);

        if(usuario is null)
        {
            return Result.Failure<int>(UsuarioErrors.NotFound);
        }

        usuario.Excluir(DateTime.UtcNow);

        _usuarioRepository.Update(usuario);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(0);
    }
}
