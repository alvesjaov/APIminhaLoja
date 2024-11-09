using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace minhaLoja.Models
{
    public class PedidoProduto
    {
        [Key, Column(Order = 0)]
        public int PedidoId { get; set; }

        [Key, Column(Order = 1)]
        public int ProdutoId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }

        [JsonIgnore]
        public Pedido? Pedido { get; set; }

        [JsonIgnore]
        public Produto? Produto { get; set; }
    }
}
