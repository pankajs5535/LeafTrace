using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LeafTrace.Application.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {

        // Get All
        Task<IEnumerable<T>> GetAllAsync();

        // Get By Id
        Task<T?> GetByIdAsync(int id);

        // Find
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // Exists
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        // Count
        Task<int> CountAsync();

        // Add
        Task AddAsync(T entity);

        // Add Multiple
        Task AddRangeAsync(IEnumerable<T> entities);

        // Update
        void Update(T entity);

        // Delete
        void Delete(T entity);

        // Delete Multiple
        void DeleteRange(IEnumerable<T> entities);
    }
}
