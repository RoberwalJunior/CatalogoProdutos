using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Shared.Application.Interfaces;
using CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Vendedores;

namespace CatalogoProdutos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendedoresController(IVendedorServiceApp vendedorService) : ControllerBase
{
    private readonly IVendedorServiceApp _vendedorService = vendedorService;

    [HttpGet]
    public async Task<IActionResult> RecuperarListaDeVendedoresCadastrados()
    {
        return Ok(await _vendedorService.RecuperarListaDeVendedoresCadastrados());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarVendedorCadastradoPeloId(int id)
    {
        var vendedor = _vendedorService.RecuperarVendedorPeloId(id);
        return vendedor != null ? Ok(vendedor) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarNovoVendedor([FromBody] CreateVendedorDto vendedorDto)
    {
        await _vendedorService.CadastrarNovoVendedor(vendedorDto);
        return Ok("Vendedor cadastrado com sucesso!");
    }
}
