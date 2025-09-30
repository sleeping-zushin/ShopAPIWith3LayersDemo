using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShopDbContext _dbContext;
        public GenericRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddNewAsync(T itemToAdd)
        {
            await _dbContext.AddAsync(itemToAdd);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var item = await _dbContext.FindAsync<T>(id);

            if (item == null)
            {
                throw new Exception("Item not found");
            }
            _dbContext.Remove(item);

            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task UpdateAsync(T itemToUpdate)
        {
            _dbContext.Update(itemToUpdate);
            await _dbContext.SaveChangesAsync();
        }
    }
}
