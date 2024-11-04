using System.ComponentModel.DataAnnotations;
using CatalogoProdutos.Shared.Domain.Entities.Enums;

namespace CatalogoProdutos.Shared.Domain.Entities;

public class Venda
{
    public int Id { get; set; }

    public int VendedorId { get; set; }
    public virtual Vendedor? Vendedor { get; set; }

    public virtual ICollection<ItemVenda>? Itens { get; set; }

    [Required]
    public decimal ValorTotal { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataDaCompra { get; set; }

    [Required]
    public StatusPagamento StatusPagamento { get; set; }
}
