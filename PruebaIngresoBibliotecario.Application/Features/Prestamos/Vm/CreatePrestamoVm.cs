using System;

namespace PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm
{
    public class CreatePrestamoVm
    {
        public Guid Id { get; set; }

        public string FechaMaximaDevolucion { get; set; }
    }
}
