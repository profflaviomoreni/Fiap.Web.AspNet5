using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet5.Models
{

    [Table("Fornecedor")]
    public class FornecedorModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FornecedorId { get; set; }

        [StringLength(70)]
        [Column("FornecedorNome")]
        public string? FornecedorNome { get; set; }

        [StringLength(14)]
        public string? Cnpj { get; set; }

        [StringLength(11)]
        public string? Telefone { get; set; }

        [StringLength(90)]
        public string? Email { get; set; }

    }
}
