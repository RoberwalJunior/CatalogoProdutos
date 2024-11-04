using System.ComponentModel.DataAnnotations;

namespace CatalogoProdutos.Shared.Domain.Entities;

public class Produto
{
    public int Id { get; set; }

    [Required]
    public int Codigo { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Nome { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataCadastrado { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataAtualizado { get; set; }

    public string? Descricao { get; set; }

    [Required]
    public decimal Valor { get; set; }

    public int Quantidade { get; set; }

    public int VendedorId { get; set; }
    public virtual Vendedor? Vendedor { get; set; }
}
