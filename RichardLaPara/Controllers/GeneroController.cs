using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace RichardLaPara.Controllers
{
    public class GeneroController : Controller
    {
        private readonly GenerosService _generosService;
        public GeneroController(DatabContext dbContext)
        {
            _generosService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            List<GeneroViewModel> response = await _generosService.GetAll();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(GeneroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Crear", vm);
            }
            await _generosService.Add(vm);
            return RedirectToRoute(new { controller = "Genero", Action = "Index" });
        }

        [HttpPut]
        public async Task<IActionResult> Editar(GeneroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Editar", vm);
            }
            await _generosService.Edit(vm, vm.Id);
            return RedirectToRoute(new { controller = "Genero", Action = "Index" });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(GeneroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Eliminar", vm);
            }
            await _generosService.Delete(vm.Id);
            return RedirectToRoute(new { controller = "Genero", Action = "Index" });
        }
    }
}
