using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using PruebaIngresoBibliotecario.Domain;
using PruebaIngresoBibliotecario.Domain.Enums;
using PruebaIngresoBibliotecario.Infrastructure.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace PruebaIngresoBibliotecario.Infrastructure.Persistence
{
    public class PersistenceContext : DbContext
    {
        public DbSet<Prestamo> Prestamos { get; set; }

        public PersistenceContext(DbContextOptions<PersistenceContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            foreach (EntityEntry<Prestamo> entry in ChangeTracker.Entries<Prestamo>())
            {
                if (entry.State == EntityState.Added)
                {
                    switch (entry.Entity.TipoUsuario)
                    {
                        case UserType.AFILIADO:
                            entry.Entity.FechaMaximaDevolucion = DateTime.Now.AddBusinessDays(10);
                            break;
                        case UserType.EMPLEADO:
                            entry.Entity.FechaMaximaDevolucion = DateTime.Now.AddBusinessDays(8);
                            break;
                        case UserType.INVITADO:
                            entry.Entity.FechaMaximaDevolucion = DateTime.Now.AddBusinessDays(7);
                            break;
                    }

                }
            }

            return base.SaveChangesAsync(token);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prestamo>()
                .Property(x => x.TipoUsuario)
                .HasConversion<int>();
        }
    }
}
