using CatalogoProdutos.Shared.Domain.Entities;
using CatalogoProdutos.Shared.Domain.Interfaces.Repositories;
using CatalogoProdutos.Shared.Domain.Interfaces.Services;
using CatalogoProdutos.Shared.Domain.Services.Base;

namespace CatalogoProdutos.Shared.Domain.Services;

public class VendedorService(IVendedorRepository repository)
    : BaseService<Vendedor>(repository), IVendedorService
{
}
