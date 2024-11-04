using AutoMapper;
using CatalogoProdutos.Shared.Domain.Entities;
using CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Vendedores;

namespace CatalogoProdutos.Shared.Application.AutoMapper.Profiles;

public class VendedorProfile : Profile
{
    public VendedorProfile()
    {
        CreateMap<CreateVendedorDto, Vendedor>();
        CreateMap<Vendedor, ReadVendedorDto>();
    }
}
