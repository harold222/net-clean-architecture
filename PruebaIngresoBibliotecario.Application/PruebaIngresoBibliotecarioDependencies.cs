using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using PruebaIngresoBibliotecario.Application.Behaviours;

namespace PruebaIngresoBibliotecario.Application
{
    public static class PruebaIngresoBibliotecarioDependencies
    {
        public static  IServiceCollection AddAplication(this IServiceCollection services)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(currentAssembly);
            services.AddValidatorsFromAssembly(currentAssembly);
            services.AddMediatR(currentAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
