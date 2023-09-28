using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RichardLaPara.Controllers
{
    public class SerieController : Controller
    {
        private readonly SeriesService _seriesService;
        private readonly GenerosService _generoService;
        private readonly ProductoraService _productoraService;
        private readonly Series_GeneroService _serie_generoService;

        public SerieController(DatabContext dbContext)
        {
            _seriesService = new(dbContext);
            _generoService = new(dbContext);
            _productoraService = new(dbContext);
            _serie_generoService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            List<SerieViewModel> response = await _seriesService.GetAll(null, null);
            return View(response);
        }

        public async Task<IActionResult> Crear()
        {
            Genero_ProductoraCreateViewModel vm = new();
            vm.Productora = await _productoraService.GetAll();
            vm.Genero = await _generoService.GetAll();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(SerieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Crear", vm);
            }
            var response = await _seriesService.Add(vm);
            Series_GeneroViewModel request = new();
            request.IdSerie = response.Id;
            request.IdGenero = response.Id;
            _serie_generoService.Add(request);
            return RedirectToRoute(new { controller = "Serie", Action = "Index" });
        }

        [HttpPut]
        public async Task<IActionResult> Editar(SerieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Editar", vm);
            }
            await _seriesService.Edit(vm, vm.Id);
            return RedirectToRoute(new { controller = "Serie", Action = "Index" });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(SerieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Eliminar", vm);
            }
            await _seriesService.Delete(vm.Id);
            return RedirectToRoute(new { controller = "Serie", Action = "Index" });
        }
    }
}
