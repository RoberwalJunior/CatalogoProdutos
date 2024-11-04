using System.Net;
using System.Net.Http.Json;
using CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Vendedores;

namespace CatalogoProdutos.Integration.Test.API;

public class VendedoresControllerTest(CatalogoProdutosApplicationFactory app)
        : IClassFixture<CatalogoProdutosApplicationFactory>
{
    private readonly CatalogoProdutosApplicationFactory _app = app;

    [Fact]
    public async Task GET_Recuperar_Lista_Vendedores_Cadastrados()
    {
        using var client = _app.CreateClient();

        var listaVendedoresDto = await client.GetFromJsonAsync<List<ReadVendedorDto>>($"/api/vendedores");

        Assert.NotNull(listaVendedoresDto);
    }

    [Fact]
    public async Task GET_Recuperar_Vendedor_Cadastrado_Pelo_Id()
    {
        var vendedorExistente = await _app.RecuperarUmVendedorJaCadastrado();
        using var client = _app.CreateClient();

        var vendedorDto = await client.GetFromJsonAsync<ReadVendedorDto>($"/api/vendedores/{vendedorExistente.Id}");

        Assert.NotNull(vendedorDto);
        Assert.Equal(vendedorExistente.Id, vendedorDto.Id);
        Assert.Equal(vendedorExistente.Nome, vendedorDto.Nome);
    }

    [Fact]
    public async Task POST_Retornar_Status_Ok_Quando_Cadastra_Vendedor_Com_Exito()
    {
        var vendedorDto = new CreateVendedorDto()
        {
            Nome = "Vendedor de Teste"
        };
        using var client = app.CreateClient();

        var result = await client.PostAsJsonAsync("/api/vendedores", vendedorDto);

        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }
}
