using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository;
using Fiap.Web.AspNet5.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet5.Controllers
{
    public class RepresentanteController : Controller
    {
        private readonly IRepresentanteRepository representanteRepository;

        public RepresentanteController(IRepresentanteRepository _representanteRepository)
        {
            representanteRepository = _representanteRepository;
        }

        public IActionResult Index()
        {
            var representantes = representanteRepository.FindAll();

            return representantes != null ? 
                          View(representantes) :
                          Problem("Entity set 'DataContext.Representantes'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var representanteModel = representanteRepository.FindById((int)id);
            if (representanteModel == null)
            {
                return NotFound();
            }

            return View(representanteModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RepresentanteModel representanteModel)
        {
            if (ModelState.IsValid)
            {
                representanteRepository.Insert(representanteModel);
                return RedirectToAction(nameof(Index));
            }
            return View(representanteModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var representanteModel = representanteRepository.FindById((int)id);
            if (representanteModel == null)
            {
                return NotFound();
            }
            return View(representanteModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RepresentanteModel representanteModel)
        {
            if (id != representanteModel.RepresentanteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    representanteRepository.Update(representanteModel);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(representanteModel);
        }

        // GET: Representante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var representanteModel = representanteRepository.FindById((int)id);
            if (representanteModel == null)
            {
                return NotFound();
            }

            return View(representanteModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            representanteRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
