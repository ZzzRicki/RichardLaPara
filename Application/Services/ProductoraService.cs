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
    public class ProductoraService
    {
        private readonly ProductoraRepository _productoraRepository;
        public ProductoraService(DatabContext dbContext)
        {
            _productoraRepository = new(dbContext);
        }

        public async Task Add(ProductoraViewModel vm)
        {
            Productora request = new();
            request.Nombre = vm.Nombre;
            await _productoraRepository.AddAsync(request);
        }

        public async Task Edit(ProductoraViewModel vm, int Id)
        {
            Productora request = new();
            request.Id = Id;
            request.Nombre = vm.Nombre;
            await _productoraRepository.EditAsync(request);
        }

        public async Task Delete(int Id)
        {
            var response = await _productoraRepository.GetByIdAsync(Id);
            await _productoraRepository.DeleteAsync(response);
        }

        public async Task<List<ProductoraViewModel>> GetAll()
        {
            var response = await _productoraRepository.GetAllAsync();
            return response.Select(x => new ProductoraViewModel
            {
                Nombre = x.Nombre,
                Id = x.Id
            }).ToList();
        }
    }
}
