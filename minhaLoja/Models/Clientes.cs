namespace minhaLoja.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string? NomeCliente { get; set; }
        public string? EmailCliente { get; set; }
        public string? NumeroCliente { get; set; }
        public DateTime DataNascimento { get; set; }

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
