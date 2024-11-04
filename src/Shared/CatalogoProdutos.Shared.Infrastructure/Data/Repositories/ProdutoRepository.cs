using CatalogoProdutos.Shared.Domain.Entities;
using CatalogoProdutos.Shared.Domain.Interfaces.Repositories;
using CatalogoProdutos.Shared.Infrastructure.Data.Context;
using CatalogoProdutos.Shared.Infrastructure.Data.Repositories.Base;

namespace CatalogoProdutos.Shared.Infrastructure.Data.Repositories;

public class ProdutoRepository(AppDbContext context) 
    : BaseRepository<Produto>(context), IProdutoRepository
{
}
