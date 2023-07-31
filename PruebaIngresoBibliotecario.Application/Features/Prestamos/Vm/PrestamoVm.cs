using PruebaIngresoBibliotecario.Domain.Enums;
using System;

namespace PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm
{
    public class PrestamoVm
    {
        public Guid Id { get; set; }

        public Guid Isbn { get; set; }

        public string IdentificacionUsuario { get; set; }

        public UserType TipoUsuario { get; set; }

        public DateTime FechaMaximaDevolucion { get; set; }
    }
}
