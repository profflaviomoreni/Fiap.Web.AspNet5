using AutoMapper;
using Fiap.Web.AspNet5.Controllers.Filters;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;
using Fiap.Web.AspNet5.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet5.Controllers
{
    [FiapLogFilter]
    [FiapAuthFilter]
    public class ClienteController : Controller
    {

        private readonly IClienteRepository clienteRepository;
        private readonly IRepresentanteRepository representanteRepository;
        private readonly IMapper mapper;

        public ClienteController(
            IClienteRepository _clienteRepository, 
            IRepresentanteRepository _representanteRepository,
            IMapper _mapper)
        {
            clienteRepository = _clienteRepository;
            representanteRepository = _representanteRepository;
            mapper = _mapper;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var vm = new ClientePesquisaViewModel();
            vm.Representantes = LoadRepresentantes();

            return View(vm);
        }


        [HttpPost]
        public IActionResult Pesquisar(ClientePesquisaViewModel vm)
        {
            vm.Representantes = LoadRepresentantes();

            var listaClienteModel = clienteRepository
                .FindByNomeAndEmailAndRepresentante(vm.ClienteNome, vm.ClienteEmail, vm.RepresentanteId);

            var listaClienteVM = mapper.Map<List<ClienteViewModel>>(listaClienteModel);

            vm.Clientes = listaClienteVM;

            return View(nameof(Index), vm);
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


        private SelectList LoadRepresentantes()
        {
            var listaRepresentante = representanteRepository.FindAll();
            return new SelectList(listaRepresentante, "RepresentanteId", "NomeRepresentante");
        }



    }
}
