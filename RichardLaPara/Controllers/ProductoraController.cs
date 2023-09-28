using Application.Services;
using Application.ViewModels;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RichardLaPara.Models;

namespace RichardLaPara.Controllers
{
    public class ProductoraController : Controller
    {
        private readonly ProductoraService _productoraService;
        private readonly DatabContext DBSerieContext;
        public ProductoraController(DatabContext dbContext)
        {

            this.DBSerieContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var ViewModelProductIndex = new ProductoraViewModel();

            var query = DBSerieContext.Productora.AsQueryable();

            ViewModelProductIndex.data = query.ToList();


            return View(ViewModelProductIndex);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ProductoraViewModel vm)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    var productora = new Productora();
                    productora.Nombre = vm.Nombre;


                    DBSerieContext.Productora.Add(productora);
                    DBSerieContext.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {

            }


            await _productoraService.Add(vm);
            return RedirectToRoute(new { controller = "Productora", Action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProductoraViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var productora = new Productora();
                 


                    DBSerieContext.Productora.Add(productora);
                    DBSerieContext.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(ProductoraViewModel vm)
        {
            var id = vm.Id;

            var productor = DBSerieContext.Productora.Find(id);
            DBSerieContext.Productora.Remove(productor);
            DBSerieContext.SaveChanges();


            return RedirectToAction("Index");
        }

    }

}