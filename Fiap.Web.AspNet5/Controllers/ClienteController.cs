using Fiap.Web.AspNet5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet5.Controllers
{
    public class ClienteController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            //return Content("Fiap Asp.Net Core Shift 2023");
            return View();
        }


        [HttpGet]
        public IActionResult Novo()
        {
            //return Content("Novo Cliente");
            return View();
        }


        [HttpPost]
        public IActionResult Novo(ClienteModel clienteModel)
        {

            Console.WriteLine(clienteModel.Nome);
            Console.WriteLine(clienteModel.Sobrenome);

            // classeBancoDados.Insert(clienteModel);
            //var mensagem = $"O cliente {clienteModel.Nome} foi cadastrado com sucesso";
            //ViewBag.Mensagem = mensagem;

            ViewBag.Cliente = clienteModel;

            return View("Sucesso");
        }

    }
}
