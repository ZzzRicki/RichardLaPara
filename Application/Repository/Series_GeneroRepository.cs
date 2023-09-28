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
    public class Series_GeneroRepository
    {
        private readonly DatabContext _dbContext;
        public Series_GeneroRepository(DatabContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Series_Generos series_generos)
        {
            await _dbContext.Series_Generos.AddAsync(series_generos);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Series_Generos series_generos)
        {
            _dbContext.Entry(series_generos).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Series_Generos series_generos)
        {
            _dbContext.Set<Series_Generos>().Remove(series_generos);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Series_Generos>> GetAllAsync()
        {
            return await _dbContext.Set<Series_Generos>().ToListAsync();
        }

        public async Task<Series_Generos> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<Series_Generos>().FindAsync(Id);
        }
    }
}
