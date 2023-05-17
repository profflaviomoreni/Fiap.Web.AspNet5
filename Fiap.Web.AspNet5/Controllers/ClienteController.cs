using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet5.Controllers
{
    public class ClienteController : Controller
    {

        private readonly ClienteRepository clienteRepository;
        private readonly RepresentanteRepository representanteRepository;

        public ClienteController(DataContext dataContext)
        {
            clienteRepository = new ClienteRepository(dataContext);
            representanteRepository = new RepresentanteRepository(dataContext);
        }


        [HttpGet]
        public IActionResult Index()
        {
            //var lista = clienteRepository.FindByNomeAndEmailAndRepresentante("Roberto", "br", 0);

            var listaClientes = clienteRepository.FindAllWithRepresentante();
            return View(listaClientes);
        }


        [HttpGet]
        public IActionResult Novo()
        {
            ComboRepresentantes();

            return View(new ClienteModel());
        }


        [HttpPost]
        public IActionResult Novo(ClienteModel clienteModel)
        {

            if (String.IsNullOrEmpty(clienteModel.Nome))
            {
                ViewBag.Mensagem = $"O nome do cliente é requerido.";

                ComboRepresentantes();

                return View(clienteModel);
            }
            else
            {
                clienteRepository.Insert(clienteModel);

                TempData["Mensagem"] = $"O cliente {clienteModel.Nome} foi cadastrado com sucesso";

                return RedirectToAction("Index", "Cliente");
            }
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            var clienteModel = clienteRepository.FindById(id);
            ComboRepresentantes();
            return View(clienteModel);
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {
            if (String.IsNullOrEmpty(clienteModel.Nome))
            {
                ViewBag.Mensagem = $"O nome do cliente é requerido.";
                ComboRepresentantes();
                return View(clienteModel);
            }
            else
            {
                TempData["Mensagem"] = $"O cliente {clienteModel.Nome} foi alterado com sucesso";
                clienteRepository.Update(clienteModel);

                return RedirectToAction("Index", "Cliente");
            }

        }


        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var clienteModel = clienteRepository.FindByIdWithRepresentante(id);

            return View(clienteModel);
        }



        [HttpGet]
        public IActionResult Remover(int id)
        {
            clienteRepository.Delete(id);

            TempData["Mensagem"] = $"O cliente foi removido com sucesso";

            return RedirectToAction("Index", "Cliente");
        }





        private void ComboRepresentantes()
        {
            var listaRepresentante = representanteRepository.FindAll();

            var selectListaRepresentante = 
                new SelectList(listaRepresentante, "RepresentanteId", "NomeRepresentante");

            ViewBag.Representantes = selectListaRepresentante;
        }


    }
}
