using MediatR;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm;
using PruebaIngresoBibliotecario.Domain.Enums;
using System;

namespace PruebaIngresoBibliotecario.Application.Features.Prestamos.Commands
{
    public class CreatePrestamoCommand : IRequest<CreatePrestamoVm>
    {
        public Guid Isbn { get; set; } = Guid.NewGuid();

        public string IdentificacionUsuario { get; set; } = "";

        public UserType TipoUsuario { get; set; } = UserType.AFILIADO;
    }
}
