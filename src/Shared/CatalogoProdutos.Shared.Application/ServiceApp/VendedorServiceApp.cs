using AutoMapper;
using CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Vendedores;
using CatalogoProdutos.Shared.Application.Interfaces;
using CatalogoProdutos.Shared.Domain.Entities;
using CatalogoProdutos.Shared.Domain.Interfaces.Services;

namespace CatalogoProdutos.Shared.Application.ServiceApp;

public class VendedorServiceApp(IMapper mapper, IVendedorService service) 
    : IVendedorServiceApp
{
    private readonly IMapper _mapper = mapper;
    private readonly IVendedorService _service = service;

    public async Task<IEnumerable<ReadVendedorDto>> RecuperarListaDeVendedoresCadastrados()
    {
        var vendedores = await _service.GetModelsAsync();
        return _mapper.Map<IEnumerable<ReadVendedorDto>>(vendedores);
    }

    public ReadVendedorDto? RecuperarVendedorPeloId(int id)
    {
        var vendedor = _service.GetModelById(id);
        return vendedor != null ? _mapper.Map<ReadVendedorDto>(vendedor) : null;
    }

    public async Task<bool> CadastrarNovoVendedor(CreateVendedorDto vendedorDto)
    {
        var vendedor = _mapper.Map<Vendedor>(vendedorDto);
        return await _service.CreateModel(vendedor);
    }
}
