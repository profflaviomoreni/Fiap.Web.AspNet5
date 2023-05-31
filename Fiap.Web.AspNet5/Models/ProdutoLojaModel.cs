using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet5.Models
{
    [Table("ProdutoLoja")]
    [Index(nameof(ProdutoId), nameof(LojaId), IsUnique = true)]
    public class ProdutoLojaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoLojaId { get; set; } // PK

        public int ProdutoId { get; set; }  // FK do Produto
        
        [ForeignKey(nameof(ProdutoId))]
        public ProdutoModel Produto { get; set; } // Navigation Property

        public int LojaId { get; set; } // FK do Loja
        
        [ForeignKey(nameof(LojaId))]
        public LojaModel Loja { get; set; } // Navigation Property


    }
}
