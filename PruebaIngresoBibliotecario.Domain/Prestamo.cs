using PruebaIngresoBibliotecario.Domain.Enums;
using System;

namespace PruebaIngresoBibliotecario.Domain
{
    public class Prestamo
    {
        public Guid Id { get; set; }

        public Guid Isbn { get; set; }

        public string IdentificacionUsuario { get; set; }

        public UserType TipoUsuario { get; set; }

        public DateTime FechaMaximaDevolucion { get; set; }
    }
}
