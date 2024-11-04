using System.Net;
using System.Net.Http.Json;
using CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Estoque;

namespace CatalogoProdutos.Integration.Test.API;

public class EstoqueControllerTest(CatalogoProdutosApplicationFactory app)
        : IClassFixture<CatalogoProdutosApplicationFactory>
{
    private readonly CatalogoProdutosApplicationFactory _app = app;

    [Fact]
    public async Task GET_Recuperar_Lista_Produtos_Cadastrados()
    {
        using var client = _app.CreateClient();
        var produtoExistente = await _app.RecuperarUmProdutoJaCadastrado();
        var estoqueDto = new UpdateEstoqueDto()
        {
            Quantidade = 100
        };

        var result = await client.PostAsJsonAsync($"/api/estoque/adicionar/{produtoExistente.Id}", estoqueDto);

        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }
}
