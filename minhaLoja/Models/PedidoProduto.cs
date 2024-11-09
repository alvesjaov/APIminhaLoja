using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace minhaLoja.Models
{
    public class PedidoProduto
    {
        [Key]
        public int PedidoId { get; set; }

        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }

        [Required]
        [JsonIgnore]
        public Pedido? Pedido { get; set; }

        [Required]
        [JsonIgnore]
        public Produto? Produto { get; set; }
    }
}
