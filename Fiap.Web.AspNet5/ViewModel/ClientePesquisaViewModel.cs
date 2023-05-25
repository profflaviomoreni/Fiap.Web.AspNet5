using Fiap.Web.AspNet5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet5.ViewModel
{
    public class ClientePesquisaViewModel
    {
        [Display(Name = "Digite parte de um nome")]
        public string ClienteNome { get; set; }

        [Display(Name = "Digite parte do email")]
        public string ClienteEmail { get; set; }

        [Display(Name = "Selecione um representante")]
        public int RepresentanteId { get; set; }

        public SelectList Representantes { get; set; }

        public IList<ClienteViewModel> Clientes { get; set; }

    }
}
