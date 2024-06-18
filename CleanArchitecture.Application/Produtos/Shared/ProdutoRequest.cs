namespace CleanArchitecture.Application.Produtos.Shared;

public sealed class ProdutoRequest
{
    public string Nome { get; set; } = null!;

    public string Descrição { get; set; } = null!;

    public string? Cor { get; set; }

    public string? Marca { get; set; }

    public bool? Garantia { get; set; }
}
