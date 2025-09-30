using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddNewAsync(T itemToAdd);
        Task UpdateAsync(T itemToUpdate);
        public Task<bool> DeleteByIdAsync(int id);
        public Task<bool> SaveChangesAsync();
    }
}
