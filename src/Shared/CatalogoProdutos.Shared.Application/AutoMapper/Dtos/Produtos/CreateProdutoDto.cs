using System.ComponentModel.DataAnnotations;

namespace CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Produtos;

public class CreateProdutoDto
{
    [Required(ErrorMessage = "O Id do Vendedor é obrigatório!")]
    public int VendedorId { get; set; }

    [Required(ErrorMessage = "O Código do produto é obrigatório!")]
    [Range(0, Double.PositiveInfinity, ErrorMessage = "Código do produto invalido!")]
    public int Codigo { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório!")]
    [StringLength(50, ErrorMessage = "O nome do produto não pode ter mais de 50 caracteres!")]
    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    [Required(ErrorMessage = "O valor unitário do produto é obrigatório!")]
    [Range(0, Double.PositiveInfinity, ErrorMessage = "Valor unitário do produto invalido!")]
    public decimal Valor { get; set; }

    [Range(0, Double.PositiveInfinity, ErrorMessage = "Quantidade do produto invalido!")]
    public int Quantidade { get; set; } = 0;

    public DateTime DataCadastrado { get; private set; } = DateTime.Now;

    public DateTime DataAtualizado { get; private set; } = DateTime.Now;
}
