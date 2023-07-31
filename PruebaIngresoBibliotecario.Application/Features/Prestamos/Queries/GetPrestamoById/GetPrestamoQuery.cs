using MediatR;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm;
using System;

namespace PruebaIngresoBibliotecario.Application.Features.Prestamos.Queries.GetPrestamoById
{
    public class GetPrestamoQuery : IRequest<PrestamoVm>
    {
        public Guid Id { get; set; }

        public GetPrestamoQuery(Guid id)
        {
            Id = id;
        }
    }
}
