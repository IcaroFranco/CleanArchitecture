using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Produtos;

public sealed class Produto
    : Entity<ProdutoId>
{
    private Produto() { }

    public Produto(
        string nome, 
        string descrição, 
        string? cor, 
        string? marca, 
        bool garantia,
        DateTime utcNow) : base(utcNow)
    {
        Nome = nome;
        Descrição = descrição;
        Cor = cor;
        Marca = marca;
        Garantia = garantia;
    }

    public string Nome { get; private set; } = null!;
    
    public string Descrição { get; private set; } = null!;
    
    public string? Cor { get; private set; }

    public string? Marca { get; private set; }

    public bool Garantia { get; private set; }

    protected override ProdutoId GetZeroValue()
        => ProdutoId.Zero;

    public static Produto Criar(
        string nome, 
        string descrição, 
        string? cor,
        string? marca, 
        bool? garantia,
        DateTime utcNow)
    {
        return new Produto(
            nome,
            descrição,
            cor,
            marca,
            garantia ?? false,
            utcNow);
    }

    public void Atualizar(Produto produto, DateTime utcNow)
    {
        Nome = produto.Nome;
        Descrição = produto.Descrição;
        Cor = produto.Cor;
        Marca = produto.Marca;
        Garantia = produto.Garantia;
        Update(utcNow);
    }

    public void Excluir(DateTime utcNow)
    {
        Delete(utcNow);
    }
}
