namespace CleanArchitecture.Domain.Produtos;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> GetAllAsync(
        CancellationToken cancellationToken);

    Task<Produto?> GetByIdAsync(
        ProdutoId produtoId, 
        CancellationToken cancellationToken);

    void Add(Produto produto);
    
    void Update(Produto produto);
}
