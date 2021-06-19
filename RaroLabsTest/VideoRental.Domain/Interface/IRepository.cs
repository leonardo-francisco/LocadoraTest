using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental.Domain.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetByNameAsync(string name);
        Task<List<T>> GetByGeneroAsync(string gnr);
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
