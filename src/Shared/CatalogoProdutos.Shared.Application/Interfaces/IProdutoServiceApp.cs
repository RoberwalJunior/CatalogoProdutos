using CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Produtos;

namespace CatalogoProdutos.Shared.Application.Interfaces;

public interface IProdutoServiceApp
{
    public Task<IEnumerable<ReadProdutoDto>> RecuperarListaDeProdutosCadastrados();
    public ReadProdutoDto? RecuperarProdutoPeloId(int id);
    public Task<bool> CadastrarNovoProduto(CreateProdutoDto produtoDto);
    public Task<bool> AtualizarProduto(int id, UpdateProdutoDto produtoDto);
    public Task<bool> DeletarProduto(int id);
}
