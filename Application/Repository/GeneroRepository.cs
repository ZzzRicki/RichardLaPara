using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class GeneroRepository
    {
        private readonly DatabContext _dbContext;
        public GeneroRepository(DatabContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Generos genero)
        {
            await _dbContext.Generos.AddAsync(genero);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Generos genero)
        {
            _dbContext.Entry(genero).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Generos genero)
        {
            _dbContext.Set<Generos>().Remove(genero);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Generos>> GetAllAsync()
        {
            return await _dbContext.Set<Generos>().ToListAsync();
        }

        public async Task<Generos> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<Generos>().FindAsync(Id);
        }
    }
}
