using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet5.ViewModel
{
    public class LoginViewModel
    {
        [HiddenInput]
        public int UsuarioId { get; set; }


        [Required(ErrorMessage = "Email é requerido")]
        [MaxLength(70, ErrorMessage = "O tamanho máximo do email é de 70 caracteres.")]
        [MinLength(3, ErrorMessage = "O tamanho mínimo é de 3 caracteres")]
        [Display(Name = "Email:")]
        [EmailAddress]
        public string? UsuarioEmail { get; set; }

        [Required(ErrorMessage = "Senha é requerida")]
        [Display(Name = "Senha:")]
        [MinLength(5, ErrorMessage = "O tamanho mínimo é de 5 caracteres")]
        [DataType(DataType.Password)]
        public string? UsuarioSenha { get; set; }

    }
}
