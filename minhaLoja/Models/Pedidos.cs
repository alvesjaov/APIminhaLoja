using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace minhaLoja.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Cliente Cliente { get; set; } = new Cliente();

        [Required]
        public ICollection<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();
    }
}
