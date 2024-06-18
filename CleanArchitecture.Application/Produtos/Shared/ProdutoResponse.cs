namespace CleanArchitecture.Application.Produtos.Shared;

public sealed class ProdutoResponse
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descrição { get; set; } = null!;

    public string? Cor { get; set; }

    public string? Marca { get; set; }

    public bool Garantia { get; set; }
}
