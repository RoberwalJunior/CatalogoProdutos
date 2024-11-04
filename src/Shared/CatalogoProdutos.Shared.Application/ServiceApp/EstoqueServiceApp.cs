using CatalogoProdutos.Shared.Application.Interfaces;
using CatalogoProdutos.Shared.Domain.Interfaces.Services;
using CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Estoque;

namespace CatalogoProdutos.Shared.Application.ServiceApp;

public class EstoqueServiceApp(IProdutoService service) : IEstoqueServiceApp
{
    private readonly IProdutoService _service = service;

    public async Task<bool> AdicionarProdutosNoEstoque(int produtoId, UpdateEstoqueDto estoqueDto)
    {
        var produto = _service.GetModelById(produtoId);
        if (produto == null) return false;
        produto.Quantidade += estoqueDto.Quantidade;
        return await _service.UpdateModel(produto);
    }
}
