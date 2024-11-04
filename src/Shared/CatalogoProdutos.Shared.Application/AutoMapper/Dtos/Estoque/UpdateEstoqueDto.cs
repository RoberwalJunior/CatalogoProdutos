using System.ComponentModel.DataAnnotations;

namespace CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Estoque;

public class UpdateEstoqueDto
{
    [Required(ErrorMessage = "Quantidade é obrigatório!")]
    [Range(0, Double.PositiveInfinity, ErrorMessage = "Valor invalido!")]
    public int Quantidade { get; set; }
}
