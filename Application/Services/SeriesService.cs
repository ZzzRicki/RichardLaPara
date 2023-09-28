using Application.Repository;
using Application.ViewModels;
using Azure;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SeriesService
    {
        private readonly SeriesRepository _seriesRepository;
        public SeriesService(DatabContext dbContext)
        {
            _seriesRepository = new(dbContext);
        }

        public async Task<Series> Add(SerieViewModel vm)
        {
            Series request = new();
            request.Nombre = vm.Nombre;
            request.ImagenPortada = vm.ImagenPortada;
            request.Uri = vm.Uri;
            request.IdProductora = vm.IdProductora;

            return await _seriesRepository.AddAsync(request);
        }

        public async Task Edit(SerieViewModel vm, int Id)
        {
            Series request = new();
            request.Nombre = vm.Nombre;
            request.ImagenPortada = vm.ImagenPortada;
            request.Uri = vm.Uri;
            request.IdProductora = vm.IdProductora;

            await _seriesRepository.EditAsync(request);
        }

        public async Task Delete(int Id)
        {
            var response = await _seriesRepository.GetByIdAsync(Id);
            await _seriesRepository.DeleteAsync(response);
        }

        public async Task<List<SerieViewModel>> GetAll(String? titulo, int? IdProductora)
        {
            var response = await _seriesRepository.GetAllAsync();

            if (IdProductora != null && IdProductora != 0)
            {
                response = response.Where(x => x.IdProductora ==  IdProductora).ToList();
            }
            if(titulo != null && titulo.Length != 0)
            {
                response = response.Where(x => x.Nombre.ToLower() == titulo.ToLower()).ToList();

            }
            return response.Select(x => new SerieViewModel
            {
                Uri = x.Uri,
                IdProductora = x.IdProductora,
                ImagenPortada = x.ImagenPortada,
                Nombre = x.Nombre
            }).ToList();
        }

        public async Task<SerieViewModel> GetById(int Id)
        {
            var response = await _seriesRepository.GetByIdAsync(Id);
            return new SerieViewModel
            {
                Id = response.Id,
                IdProductora = response.IdProductora,
                ImagenPortada = response.ImagenPortada,
                Nombre = response.Nombre,
                Uri = response.Uri
            };
        }
    }
}
