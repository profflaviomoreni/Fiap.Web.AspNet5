using AutoMapper;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;
using Fiap.Web.AspNet5.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet5.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public LoginController(IUsuarioRepository _usuarioRepository, IMapper _mapper)
        {
            usuarioRepository = _usuarioRepository;
            mapper = _mapper;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login( LoginViewModel loginViewModel )
        {

            if ( ModelState.IsValid ) {

                var usuario = mapper.Map<UsuarioModel>(loginViewModel);

                var usuarioLogado = usuarioRepository.Login(usuario);

                if ( usuarioLogado == null || usuarioLogado.UsuarioId == 0 )
                {
                    ViewBag.ErrorMensagem = "Login ou senha inválida";
                    return View(nameof(Index));
                } 
                else
                {
                    loginViewModel = mapper.Map<LoginViewModel>(usuarioLogado);

                    var vmJson = Newtonsoft.Json.JsonConvert.SerializeObject(loginViewModel);
                    HttpContext.Session.SetString("usuarioLogado", vmJson);

                    return RedirectToAction(nameof(Index), "Home" );
                }
            } 
            else
            {
                return View(nameof(Index));
            }
        }


        [HttpGet]
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index), "Home");
        }

    }
}
