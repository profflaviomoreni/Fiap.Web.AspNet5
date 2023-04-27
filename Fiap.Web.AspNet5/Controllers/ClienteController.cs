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
            //var clienteModel = new ClienteModel();

            return View(new ClienteModel());
        }


        [HttpPost]
        public IActionResult Novo(ClienteModel clienteModel)
        {

            if (String.IsNullOrEmpty(clienteModel.Nome))
            {
                ViewBag.Mensagem = $"O nome do cliente é requerido.";

                //return RedirectToAction("Editar", "Cliente", new { id = clienteModel.ClienteId} );
                return View(clienteModel);
            }
            else
            {
                Console.WriteLine(clienteModel.Nome);

                TempData["Mensagem"] = $"O cliente {clienteModel.Nome} foi cadastrado com sucesso";

                return RedirectToAction("Index", "Cliente");
            }
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            // var cliente = "SELECT * FROM tabelaClientes WHERE id = {id}";
            var clienteModel = new ClienteModel
            {
                ClienteId = 1,
                Nome = "Flávio",
                Email = "fmoreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS1"
            };



            return View(clienteModel);
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {
            if (String.IsNullOrEmpty(clienteModel.Nome))
            {
                ViewBag.Mensagem = $"O nome do cliente é requerido.";

                //return RedirectToAction("Editar", "Cliente", new { id = clienteModel.ClienteId} );
                return View(clienteModel);
            }
            else
            {
                //UPDATE tabelaClientes SET Nome = {clienteModel.Nome} ... WHERE id = {clienteModel.ClienteId}
                TempData["Mensagem"] = $"O cliente {clienteModel.Nome} foi alterado com sucesso";

                return RedirectToAction("Index", "Cliente");
            }

        }


        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            // var cliente = "SELECT * FROM tabelaClientes WHERE id = {id}";
            var clienteModel = new ClienteModel
            {
                ClienteId = 1,
                Nome = "Flávio",
                Email = "fmoreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS1"
            };

            return View(clienteModel);
        }


        [HttpGet]
        public IActionResult Remover(int id)
        {
            //"DELETE FROM tabelaCliente WHERE id = {id}";

            Console.WriteLine($" id: {id}");

            TempData["Mensagem"] = $"O cliente foi removido com sucesso";

            return RedirectToAction("Index", "Cliente");
        }
    }
}
