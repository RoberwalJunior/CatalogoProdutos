using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Shared.Application.Interfaces;
using CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Estoque;

namespace CatalogoProdutos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController(IEstoqueServiceApp estoqueService) : ControllerBase
    {
        private readonly IEstoqueServiceApp _estoqueService = estoqueService;

        [HttpPost("Adicionar/{produtoId}")]
        public async Task<ActionResult> AdicionarProdutosNoEstoque(int produtoId, [FromBody] UpdateEstoqueDto estoqueDto)
        {
            return await _estoqueService.AdicionarProdutosNoEstoque(produtoId, estoqueDto) 
                ? NoContent() : NotFound();
        }
    }
}
