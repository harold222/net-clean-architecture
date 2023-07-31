using MediatR;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm;
using System.Collections.Generic;

namespace PruebaIngresoBibliotecario.Application.Features.Prestamos.Queries.GetAllPrestamos
{
    public class GetAllPrestamosQuery : IRequest<IReadOnlyList<PrestamoVm>>
    {
    }
}
