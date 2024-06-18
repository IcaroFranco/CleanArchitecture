using CleanArchitecture.Application.Produtos.DeleteProduto;
using CleanArchitecture.Application.Produtos.GetProdutoById;
using CleanArchitecture.Application.Produtos.GetProdutos;
using CleanArchitecture.Application.Produtos.PostProduto;
using CleanArchitecture.Application.Produtos.PutProduto;
using CleanArchitecture.Application.Produtos.Shared;
using CleanArchitecture.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers;

[ApiController]
[Route("api/v1/{usuarioId}/produtos")]
public sealed class ProdutosController : ControllerBase
{
    private readonly ISender _sender;

    public ProdutosController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [Consumes("application/json")]
    public async Task<Results<Ok<IEnumerable<ProdutoResponse>>, NotFound<Error>>>
        GetProdutosAsync(Guid usuarioId, CancellationToken cancellationToken)
    {
        var query = new GetProdutosQuery(usuarioId);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSucess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound(result.Error);
    }

    // get by id
    [HttpGet("{id}")]
    [Consumes("application/json")]
    public async Task<Results<Ok<ProdutoResponse>, NotFound<Error>>>
        GetProdutoByIdAsync(Guid usuarioId, int id, CancellationToken cancellationToken)
    {
        var query = new GetProdutoByIdQuery(usuarioId, id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSucess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound(result.Error);
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<Results<NoContent, BadRequest<Error>>> PostProdutoAsync(
        Guid usuarioId,
        [FromBody] ProdutoRequest request,
        CancellationToken cancellationToken)
    {
        var command = new PostProdutoCommand(usuarioId, request);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess
            ? TypedResults.NoContent()
            : TypedResults.BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<Results<Ok<ProdutoResponse>, BadRequest<Error>>> PutProdutoAsync(
        Guid usuarioId,
        int id,
        [FromBody] ProdutoRequest request,
        CancellationToken cancellationToken)
    {
        var command = new PutProdutoCommand(usuarioId, id, request);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess
            ? TypedResults.Ok(result.Value)
            : TypedResults.BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<Results<NoContent, BadRequest<Error>>> DeleteProdutoAsync(
        Guid usuarioId, int id, CancellationToken cancellationToken)
    {
        var command = new DeleteProdutoCommand(usuarioId, id);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess
            ? TypedResults.NoContent()
            : TypedResults.BadRequest(result.Error);
    }
}
