using CleanArchitecture.Application.Abstraction.Handlers;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Usuarios;

namespace CleanArchitecture.Application.Usuarios.GetUsuarios;

internal sealed class GetUsuariosQueryHandler
    : IQueryHandler<GetUsuariosQuery, IEnumerable<UsuarioResponse>>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public GetUsuariosQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Result<IEnumerable<UsuarioResponse>>> Handle(
        GetUsuariosQuery request,
        CancellationToken cancellationToken)
    {
        //var UserId = new UsuarioId(request.UsuarId);

        //var possuiPermissao = await _usuarioRepository.GetByIdAsync(UserId, cancellationToken);

        //if(possuiPermissao is null || possuiPermissao.Admin == false)
        //{
        //    return Result.Failure<IEnumerable<UsuarioResponse>>(UsuarioErrors.Unauthorized);
        //}

        var usuarios = await _usuarioRepository.GetAllAsync(cancellationToken);

        return usuarios is null
            ? Result.Failure<IEnumerable<UsuarioResponse>>(UsuarioErrors.NotFound)
            : Result.Success(usuarios.Select(u => u.ToResponse()));
    }
}
