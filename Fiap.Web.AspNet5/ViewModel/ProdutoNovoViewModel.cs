using Fiap.Web.AspNet5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Fiap.Web.AspNet5.ViewModel
{
    public class ProdutoNovoViewModel
    {

        [Required]
        public string ProdutoNome { get; set; }

        [AllowNull]
        public SelectList Lojas { get; set; } // Exibir todas as lojas com seu Id e Nome.

        [Required]
        public ICollection<int> LojaId { get; set; } //Loja

    }
}
