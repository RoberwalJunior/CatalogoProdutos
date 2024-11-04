using System.Net;
using System.Net.Http.Json;
using CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Produtos;

namespace CatalogoProdutos.Integration.Test.API;

public class ProdutosControllerTest(CatalogoProdutosApplicationFactory app)
        : IClassFixture<CatalogoProdutosApplicationFactory>
{
    private readonly CatalogoProdutosApplicationFactory _app = app;

    [Fact]
    public async Task GET_Recuperar_Lista_Produtos_Cadastrados()
    {
        using var client = _app.CreateClient();

        var listaProdutosDto = await client.GetFromJsonAsync<List<ReadProdutoDto>>($"/api/produtos");

        Assert.NotNull(listaProdutosDto);
    }

    [Fact]
    public async Task GET_Recuperar_Produto_Cadastrado_Pelo_Id()
    {
        var produtoExistente = await _app.RecuperarUmProdutoJaCadastrado();
        using var client = _app.CreateClient();

        var produtoDto = await client.GetFromJsonAsync<ReadProdutoDto>($"/api/produtos/{produtoExistente.Id}");

        Assert.NotNull(produtoDto);
        Assert.Equal(produtoExistente.Nome, produtoDto.Nome);
        Assert.Equal(produtoExistente.Codigo, produtoDto.Codigo);
        Assert.Equal(produtoExistente.Quantidade, produtoDto.Quantidade);
        Assert.Equal(produtoExistente.DataCadastrado, produtoDto.DataCadastrado);
    }

    [Fact]
    public async Task POST_Retornar_Status_Ok_Quando_Cadastra_Produto_Com_Exito()
    {
        //Arrange
        var produtoDto = new CreateProdutoDto()
        {
            Codigo = 1000,
            Nome = "Produto para teste de API",
            Descricao = "Produto para teste de API",
            Quantidade = 10,
            Valor = 10
        };
        using var client = app.CreateClient();

        //act
        var result = await client.PostAsJsonAsync("/api/produtos", produtoDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }
}