using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Shared.Application.Interfaces;
using CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Produtos;

namespace CatalogoProdutos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController(IProdutoServiceApp produtoService) : ControllerBase
{
    private readonly IProdutoServiceApp _produtoService = produtoService;

    [HttpGet]
    public async Task<IActionResult> RecuperarListaDeProdutosCadastrados()
    {
        return Ok(await _produtoService.RecuperarListaDeProdutosCadastrados());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarProdutoCadastradoPeloId(int id)
    {
        var produto = _produtoService.RecuperarProdutoPeloId(id);
        return produto != null ? Ok(produto) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarNovoProduto([FromBody] CreateProdutoDto produtoDto)
    {
        await _produtoService.CadastrarNovoProduto(produtoDto);
        return Ok("Produto cadastrado com sucesso!");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
    {
        return await _produtoService.AtualizarProduto(id, produtoDto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarProduto(int id)
    {
        return await _produtoService.DeletarProduto(id) ? NoContent() : NotFound();
    }
}
