using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace minhaLoja.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int IdCliente { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string? NomeCliente { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string? EmailCliente { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string? NumeroCliente { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
    }
}
