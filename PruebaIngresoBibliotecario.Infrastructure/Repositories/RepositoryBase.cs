using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Application.Contracts.Persistence;
using PruebaIngresoBibliotecario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : class
    {

        protected readonly PersistenceContext Context;

        public RepositoryBase(PersistenceContext context)
        {
            this.Context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            this.Context.Add(entity);
            await this.Context.SaveChangesAsync();

            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await this.Context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Func<T, bool> predicate, bool disableTracking = false)
        {
            IQueryable<T> query = this.Context.Set<T>();

            if (disableTracking) query = query.AsNoTracking();

            return query.Where(predicate).ToList();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await this.Context.Set<T>().FindAsync(id);
        }
    }
}
