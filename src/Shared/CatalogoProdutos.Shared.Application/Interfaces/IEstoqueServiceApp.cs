using CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Estoque;

namespace CatalogoProdutos.Shared.Application.Interfaces;

public interface IEstoqueServiceApp
{
    public Task<bool> AdicionarProdutosNoEstoque(int produtoId, UpdateEstoqueDto estoqueDto);
}
