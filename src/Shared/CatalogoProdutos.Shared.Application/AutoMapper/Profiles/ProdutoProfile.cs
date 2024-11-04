using AutoMapper;
using CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Produtos;
using CatalogoProdutos.Shared.Domain.Entities;

namespace CatalogoProdutos.Shared.Application.AutoMapper.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<Produto, ReadProdutoDto>();
        CreateMap<UpdateProdutoDto, Produto>();
    }
}
