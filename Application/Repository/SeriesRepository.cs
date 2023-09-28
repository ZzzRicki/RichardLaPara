using Database.Models;
using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class SeriesRepository
    {
        private readonly DatabContext _dbContext;
        public SeriesRepository(DatabContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Series> AddAsync(Series series)
        {
            await _dbContext.Set<Series>().AddAsync(series);
            await _dbContext.SaveChangesAsync();
            return series;
        }

        public async Task EditAsync(Series series)
        {
            _dbContext.Entry(series).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Series series)
        {
            _dbContext.Set<Series>().Remove(series);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Series>> GetAllAsync()
        {
            return await _dbContext.Set<Series>().ToListAsync();
        }

        public async Task<Series> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<Series>().FindAsync(Id);
        }
    }
}
