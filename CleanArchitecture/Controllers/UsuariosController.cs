using CleanArchitecture.Application.Usuarios;
using CleanArchitecture.Application.Usuarios.GetUsuarios;
using CleanArchitecture.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers;

[ApiController]
//[ApiExplorerSettings(IgnoreApi = true)] // Faz que com que o Swagger ignore este controller (controle de usuário não deve ser visto).
//[Authorize] // Atributo de autorização (necessário para acessar os métodos do controller). Porém, não irei usar nesse exemplo.
[Route("api/v1/{usuarioId}/usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly ISender _sender;

    public UsuariosController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [Consumes("application/json")]
    public async Task<Results<Ok<IEnumerable<UsuarioResponse>>, NotFound<Error>>>
        GetUsuariosAsync(Guid usuarioId, CancellationToken cancellationToken)
    {
        var query = new GetUsuariosQuery(usuarioId);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSucess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound(result.Error);
    }
}
