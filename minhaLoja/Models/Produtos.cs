using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace minhaLoja.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [Required]
        public string? NomeProduto { get; set; }

        [Required]
        public string? TipoProduto { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal ValorProduto { get; set; }

        [JsonIgnore]
        public ICollection<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();
    }
}
