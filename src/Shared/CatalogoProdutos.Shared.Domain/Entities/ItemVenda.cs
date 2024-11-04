using System.ComponentModel.DataAnnotations;

namespace CatalogoProdutos.Shared.Domain.Entities;

public class ItemVenda
{
    public int Id { get; set; }

    [Required]
    public int Quantidade { get; set; }

    [Required]
    public decimal Valor { get; set; }

    [Required]
    public int VendaId { get; set; }

    public virtual Produto? Produto { get; set; }
}
