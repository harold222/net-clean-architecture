using FluentValidation;
using System;

namespace PruebaIngresoBibliotecario.Application.Features.Prestamos.Commands
{
    public class CreatePrestamoCommandValidator : AbstractValidator<CreatePrestamoCommand>
    {
        public CreatePrestamoCommandValidator() {
            RuleFor(p => p.Isbn)
                .NotEmpty().WithMessage("Debe de tener valor")
                .NotEqual(Guid.Empty);

            RuleFor(p => p.IdentificacionUsuario)
                .NotEmpty().WithMessage("Debe de tener valor")
                .MaximumLength(10).WithMessage("No debe ser mayor a 10 caracteres");

            RuleFor(p => p.TipoUsuario)
                .NotEmpty().WithMessage("Debe de tener valor")
                .NotNull().IsInEnum();
        }
    }
}
