public class Pedido
{
    public int IdPedido { get; set; }
    public int ClienteId { get; set; }
    public string Status { get; set; }

    public Cliente Cliente { get; set; }
    public ICollection<PedidoProduto> PedidoProdutos { get; set; }
}
