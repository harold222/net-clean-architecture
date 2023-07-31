using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using PruebaIngresoBibliotecario.Infrastructure;
using PruebaIngresoBibliotecario.Application;
using PruebaIngresoBibliotecario.Api.Middleware;

namespace PruebaIngresoBibliotecario.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerDocument();
            services.AddInfrastructureServices(this.Configuration);
            services.AddAplication();
            services.AddControllers();
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
