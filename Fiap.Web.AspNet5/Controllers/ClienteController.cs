using Fiap.Web.AspNet5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet5.Controllers
{
    public class ClienteController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            // SELECT * FROM tableClientes;

            var listaClientes = new List<ClienteModel>();
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 1,
                Nome = "Flávio",
                Email = "fmoreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS1"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 2,
                Nome = "Eduardo",
                Email = "eduardo@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 3,
                Nome = "Moreni",
                Email = "moreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 4,
                Nome = "Luan",
                Email = "luan@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS4"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 2,
                Nome = "Eduardo",
                Email = "eduardo@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });

            //ViewBag.Clientes = listaClientes;
            //ViewData["Clientes"] = listaClientes;
            //TempData["Clientes"] = listaClientes;

            return View(listaClientes);
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
