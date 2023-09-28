using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;
using RichardLaPara.Models;
using System.Diagnostics;

namespace RichardLaPara.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly DatabContext DBSerieContext;
      

        private readonly SeriesService _seriesService;
        public HomeController(DatabContext dbContext)
        {

            this.DBSerieContext = dbContext;
        
        }

        public async Task<IActionResult> Index()
        {
            var ViewModelSerieIndex = new SerieViewModel();

            var query = DBSerieContext.Series.AsQueryable();

            ViewModelSerieIndex.data = query.ToList();


            return View(ViewModelSerieIndex);
           
        }

        public async Task<IActionResult> Info(int Id)
        {
            SerieViewModel response = await _seriesService.GetById(Id);
            return View(response);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}