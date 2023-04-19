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
        public IActionResult Novo(string nome, string sobrenome)
        {
            return View("Sucesso");
        }


    }
}
