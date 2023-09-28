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
    public class GenerosService
    {
        private readonly GeneroRepository _generoRepository;
        public GenerosService(DatabContext dbContext) {
            _generoRepository = new(dbContext);
        }

        public async Task Add(GeneroViewModel vm)
        {
            Generos request = new();
            request.Nombre = vm.Nombre;
            await _generoRepository.AddAsync(request);
        }

        public async Task Edit(GeneroViewModel vm, int Id)
        {
            Generos request = new();
            request.Id = Id;
            request.Nombre = vm.Nombre;
            await _generoRepository.EditAsync(request);
        }

        public async Task Delete(int Id)
        {
            var response = await _generoRepository.GetByIdAsync(Id);
            await _generoRepository.DeleteAsync(response);
        }

        public async Task<List<GeneroViewModel>> GetAll()
        {
            var response = await _generoRepository.GetAllAsync();
            return response.Select(x => new GeneroViewModel
            {
                Nombre = x.Nombre,
                Id = x.Id
            }).ToList();
        }
    }
}
