using Fiap.Web.AspNet5.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet5.ViewModel
{
    public class ProdutoLojaViewModel
    {

        public int ProdutoLojaId { get; set; } 

        public int ProdutoId { get; set; }  

        public ProdutoViewModel Produto { get; set; } 

        public int LojaId { get; set; } 

        public LojaViewModel Loja { get; set; } 
    }
}
