using System.ComponentModel.DataAnnotations;

namespace CatalogoProdutos.Shared.Domain.Entities;

public class Vendedor
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Nome { get; set; }

    public virtual ICollection<Produto>? Produtos { get; set; }
    public virtual ICollection<Venda>? Vendas { get; set; }
}
