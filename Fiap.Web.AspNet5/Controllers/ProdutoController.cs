using AutoMapper;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository;
using Fiap.Web.AspNet5.Repository.Interface;
using Fiap.Web.AspNet5.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet5.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IProdutoRepository produtoRepository;
        private readonly ILojaRepository lojaRepository;
        private readonly IMapper mapper;

        public ProdutoController(IProdutoRepository _produtoRepository, ILojaRepository _lojaRepository, IMapper _mapper)
        {
            produtoRepository = _produtoRepository;
            lojaRepository = _lojaRepository;
            mapper = _mapper;
        }

        public IActionResult Index()
        {
            var produtos = produtoRepository.FindAll();
            var vm = mapper.Map<List<ProdutoViewModel>>(produtos);
            return View(vm);
        }


        [HttpGet]
        public IActionResult Novo()
        {
            var vm = new ProdutoNovoViewModel();
            vm.Lojas = LoadLojas();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Novo(ProdutoNovoViewModel produtoNovoViewModel)
        {
            try {  

                var produtoModel = new ProdutoModel();
                produtoModel.ProdutoNome = produtoNovoViewModel.ProdutoNome;
                produtoModel.ProdutosLojas = new List<ProdutoLojaModel>();

                if (produtoNovoViewModel.LojaId == null || produtoNovoViewModel.LojaId.Count < 1)
                {
                    throw new Exception("Nenhum loja selecionada para o cadastro");
                }
                else
                {
                    foreach (var item in produtoNovoViewModel.LojaId)
                    {
                        var produtoLojaModel = new ProdutoLojaModel();
                        produtoLojaModel.LojaId = item;
                        produtoLojaModel.Produto = produtoModel;

                        produtoModel.ProdutosLojas.Add(produtoLojaModel);
                    }
                }

                produtoRepository.Insert(produtoModel);

                TempData["mensagem"] = "Produto cadastrado com sucesso";
                return RedirectToAction("Index");

            } 
            catch (Exception ex)
            {
                TempData["mensagem"] = "Não foi possível cadastrar o produto, verifique se existe alguma loja selecionada";
                produtoNovoViewModel.Lojas = LoadLojas();
                return View(produtoNovoViewModel);
            }

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = produtoRepository.FindById(id);

            var vm = new ProdutoEditarViewModel();
            vm.ProdutoId = id;
            vm.ProdutoNome = produto.ProdutoNome;
            vm.LojaId = produto.ProdutosLojas.ToList().ConvertAll(obj => obj.LojaId);
            vm.Lojas = LoadLojas();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(ProdutoEditarViewModel produtoViewModel)
        {
            try
            {

                var produtoModel = new ProdutoModel();
                produtoModel.ProdutoNome = produtoViewModel.ProdutoNome;
                produtoModel.ProdutoId = produtoViewModel.ProdutoId;
                produtoModel.ProdutosLojas = new List<ProdutoLojaModel>();

                if (produtoViewModel.LojaId == null || produtoViewModel.LojaId.Count < 1)
                {
                    throw new Exception("Nenhum loja selecionada para o cadastro");
                }
                else
                {
                    foreach (var item in produtoViewModel.LojaId)
                    {
                        var produtoLojaModel = new ProdutoLojaModel();
                        produtoLojaModel.LojaId = item;
                        produtoLojaModel.Produto = produtoModel;

                        produtoModel.ProdutosLojas.Add(produtoLojaModel);
                    }
                }

                produtoRepository.Update(produtoModel);

                TempData["mensagem"] = "Produto alterado com sucesso";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["mensagem"] = "Não foi possível alterado o produto, verifique se existe alguma loja selecionada";
                produtoViewModel.Lojas = LoadLojas();
                return View(produtoViewModel);
            }

        }


        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            produtoRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }



        private SelectList LoadLojas()
        {
            var listaLojas = lojaRepository.FindAll();
            var listaLojasVM = mapper.Map<List<LojaViewModel>>(listaLojas);

            var lojasSelectList = new SelectList(listaLojasVM, "LojaId", "LojaNome");

            return lojasSelectList;
        }


    }
}
