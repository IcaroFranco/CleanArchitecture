namespace CleanArchitecture.Domain.Produtos;

public sealed record ProdutoId(int Value)
{
    public static ProdutoId From(int value) => new(value);

    public static ProdutoId Zero => new(0);
}
