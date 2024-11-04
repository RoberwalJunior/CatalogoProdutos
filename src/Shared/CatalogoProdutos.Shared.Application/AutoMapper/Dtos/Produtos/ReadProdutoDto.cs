namespace CatalogoProdutos.Shared.Application.AutoMapper.Dtos.Produtos;

public class ReadProdutoDto
{
    public int Codigo { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataCadastrado { get; set; }
    public DateTime DataAtualizado { get; set; }
}
