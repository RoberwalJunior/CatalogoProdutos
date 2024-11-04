using CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Vendedores;

namespace CatalogoProdutos.Shared.Application.Interfaces;

public interface IVendedorServiceApp
{
    public Task<IEnumerable<ReadVendedorDto>> RecuperarListaDeVendedoresCadastrados();
    public ReadVendedorDto? RecuperarVendedorPeloId(int id);
    public Task<bool> CadastrarNovoVendedor(CreateVendedorDto vendedorDto);
}
