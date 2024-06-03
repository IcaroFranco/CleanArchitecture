using CleanArchitecture.Application.Abstraction.Handlers;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Usuarios;

namespace CleanArchitecture.Application.Usuarios.PostUsuario;

internal sealed class PostUsuarioCommandHandler
    : ICommandHandler<PostUsuarioCommand, UsuarioResponse>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PostUsuarioCommandHandler(
        IUsuarioRepository usuarioRepository,
        IUnitOfWork unitOfWork)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<UsuarioResponse>> Handle(
        PostUsuarioCommand request,
        CancellationToken cancellationToken)
    {
        // Como é um exemplo, não irei validar QUEM está criando.
        // Mas poderia ter um campo GUID ID, onde vc valida se o Usuário tem permissão para criar.

        var usuario = request.Usuario.ToEntity(DateTime.UtcNow);

        if(usuario is null)
        {
            return Result.Failure<UsuarioResponse>(UsuarioErrors.BadRequest);
        }

        _usuarioRepository.Add(usuario);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(usuario.ToResponse());
    }
}
