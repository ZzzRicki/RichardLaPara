using Application.Repository;
using Application.ViewModels;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class Series_GeneroService
    {
        private readonly Series_GeneroRepository _series_GeneroRepository;
        public Series_GeneroService(DatabContext dbContext)
        {
            _series_GeneroRepository = new(dbContext);
        }

        public async Task Add(Series_GeneroViewModel vm)
        {
            Series_Generos request = new();
            request.IdSerie = vm.IdSerie;
            request.IdGenero = vm.IdGenero;
            await _series_GeneroRepository.AddAsync(request);
        }

        public async Task Edit(Series_GeneroViewModel vm, int Id)
        {
            Series_Generos request = new();
            request.IdSerie = vm.IdSerie;
            request.IdGenero = vm.IdGenero;
            await _series_GeneroRepository.EditAsync(request);
        }

        public async Task Delete(int Id)
        {
            var response = await _series_GeneroRepository.GetByIdAsync(Id);
            await _series_GeneroRepository.DeleteAsync(response);
        }
    }
}
