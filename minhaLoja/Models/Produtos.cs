public class Produto
{
    public int IdProduto { get; set; }
    public string NomeProduto { get; set; }
    public string TipoProduto { get; set; }
    public decimal ValorProduto { get; set; }

    public ICollection<PedidoProduto> PedidoProdutos { get; set; }
}
