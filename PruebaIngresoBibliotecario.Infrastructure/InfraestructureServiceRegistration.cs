using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PruebaIngresoBibliotecario.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Application.Contracts.Persistence;
using PruebaIngresoBibliotecario.Infrastructure.Repositories;

namespace PruebaIngresoBibliotecario.Infrastructure
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<PersistenceContext>(option =>
                option.UseInMemoryDatabase("PruebaIngreso")
            );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            return services;
        }
    }
}
