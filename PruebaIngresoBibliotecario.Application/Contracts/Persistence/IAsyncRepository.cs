using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAsync(Func<T, bool> predicate, bool disableTracking = false);

        Task<T> GetByIdAsync(Guid id);

        Task<T> AddAsync(T entity);
    }
}
