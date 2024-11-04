using System.ComponentModel.DataAnnotations;

namespace CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Vendedores;

public class CreateVendedorDto
{
    [Required(ErrorMessage = "O nome do vendedor é obrigatório!")]
    [StringLength(50, ErrorMessage = "O nome do vendedor não pode ter mais de 50 caracteres!")]
    public string? Nome { get; set; }
}
